using LRRS.Data.Model.Entity;
using LRRS.Data.Model.Entity.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;  

        public UserRolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [Authorize(Roles = "SuperAdmin, Administrator")]
        public async Task<IActionResult> Index(string searchString)
        {
            var users = await _userManager.Users.ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                var data  = users.Where(s => {
                    bool? result = false;

                    result |= s.FirstName?.Contains(searchString);
                    result |= s.LastName?.Contains(searchString);
                    result |= s.UserName?.Contains(searchString);
                    result |= s.SerialPassport?.Contains(searchString);
                    result |= s.Email?.Contains(searchString);

                    return  result??false; });

                if (data != null)
                {
                    users = data.ToList();
                }
                else
                {
                    users = new List<ApplicationUser>();
                }

            }

            var userRolesViewModel = new List<UserRolesViewModel>();
            foreach (ApplicationUser user in users)
            {
                var thisViewModel = new UserRolesViewModel();
                thisViewModel.UserId = user.Id;
                thisViewModel.Email = user.Email;
                thisViewModel.FirstName = user.FirstName;
                thisViewModel.LastName = user.LastName;
                thisViewModel.Roles = await GetUserRoles(user);
                userRolesViewModel.Add(thisViewModel);
            }
            return View(userRolesViewModel);
        }

        [Authorize(Roles = "SuperAdmin, Administrator")]
        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }

        [Authorize(Roles = "SuperAdmin, Administrator")]
        public async Task<IActionResult> Manage(string userId)
        {
            ViewBag.userId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            ViewBag.UserName = user.UserName;
            var model = new List<ManageUserRolesViewModel>();
            foreach (var role in _roleManager.Roles)
            {
                var userRolesViewModel = new ManageUserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                model.Add(userRolesViewModel);
            }
            return View(model);
        }

        [Authorize(Roles = "SuperAdmin, Administrator")]
        [HttpPost]
        public async Task<IActionResult> Manage(List<ManageUserRolesViewModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View();
            }
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }
            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "SuperAdmin, Administrator")]
        public async Task<IActionResult> ManageUser(string userId)
        {
            ManageUserViewModel userViewModel = new ManageUserViewModel();
            ViewBag.userId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await GetUserRoles(user);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            if (roles == null)
            {
                ViewBag.ErrorMessage = $"Roles for user Id = {userId} cannot be found";
                return View("NotFound");
            }

            userViewModel.User = user;
            userViewModel.Roles = roles;
            return View(userViewModel);
        }

        [Authorize(Roles = "SuperAdmin, Administrator")]
        [HttpPost]
        public async Task<IActionResult> ManageUser(ManageUserViewModel applicationUser, string userId)
        {
            ManageUserViewModel userViewModel = new ManageUserViewModel();
            ViewBag.userId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            user.FirstName = applicationUser.User.FirstName;
            user.LastName = applicationUser.User.LastName;
            user.Email = applicationUser.User.Email;
            user.StudentId = applicationUser.User.UserName;
            user.IsBlocked = applicationUser.User.IsBlocked;
            user.UserName = applicationUser.User.UserName;
            user.SerialPassport = applicationUser.User.SerialPassport;
            applicationUser.Roles = await GetUserRoles(user);

            var result = await _userManager.UpdateAsync(user);
            if (!string.IsNullOrEmpty(applicationUser.UnsavePassword)) 
            { 
                var hasPassword = await _userManager.AddPasswordAsync(user, applicationUser.UnsavePassword);
            }

            if (!result.Succeeded)
            {
                return View(applicationUser);
            }

            userViewModel.User = user;
            return View(applicationUser);
        }
    }
}
