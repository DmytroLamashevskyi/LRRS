using LRRS.Data.Model.Entity;
using LRRS.Data.Model.Entity.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace LRRS.Queries.DataBase
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        { 
            await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Administrator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Lecturer.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Student.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Visitor.ToString()));
        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var config = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: true)
                   .Build();
            var data = config.GetSection("SuperAdmin") as ApplicationUser;
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = data.UserName,
                Email = data.Email,
                FirstName = data.FirstName,
                LastName = data.LastName,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, data.PasswordHash);
                    await userManager.AddToRoleAsync(defaultUser, Roles.Visitor.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Student.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Lecturer.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Administrator.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
                }

            }
        }
    }
}
