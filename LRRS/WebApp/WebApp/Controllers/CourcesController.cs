using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CourcesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CourcesController(UserManager<ApplicationUser> userManager ,ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Cources
        public async Task<IActionResult> Index(string searchString)
        {
            var cources = await _context.Cource.ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                cources = cources.Where(s => s.Name.Contains(searchString)).ToList();
            }

            return View(cources); 
        }
         

        // GET: Cources/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cource = await _context.Cource
                .FirstOrDefaultAsync(m => m.Id == id);
            cource.Owner = await _context.Users.FirstOrDefaultAsync(u=>u.Id == cource.OwnerId);
            cource.Lessons =  _context.Lessons.Where(u => u.CourceId == id).ToList();
            if (cource == null)
            {
                return NotFound();
            }

            return View(cource);
        }

        // GET: Cources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cources/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cource cource)
        {
            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            cource.Owner = applicationUser;
            cource.OwnerId = applicationUser.Id;
            if (ModelState.IsValid)
            {
                _context.Add(cource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cource);
        }

        // GET: Cources/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cource = await _context.Cource.FindAsync(id);
            if (cource == null)
            {
                return NotFound();
            }
            return View(cource);
        }

        // POST: Cources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id,  Cource cource)
        {
            if (id != cource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourceExists(cource.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cource);
        }

        // GET: Cources/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cource = await _context.Cource
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cource == null)
            {
                return NotFound();
            }

            return View(cource);
        }

        // POST: Cources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cource = await _context.Cource.FindAsync(id);
            _context.Cource.Remove(cource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourceExists(string id)
        {
            return _context.Cource.Any(e => e.Id == id);
        }
    }
}
