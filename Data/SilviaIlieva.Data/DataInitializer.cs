using Microsoft.AspNetCore.Identity;
using SilviaIlieva.Data.Models;
using System.Linq;

namespace SilviaIlieva.Data
{
    public static class DataInitializer
    {
        public static void SeedAdministrator(SilviaIlievaDbContext dbContext, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            dbContext.Database.EnsureCreated();

            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new Role() { Name = "Administrator" };
                roleManager.CreateAsync(role).Wait();
            }

            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                var administrator = new User() { UserName = "Admin" };
                var result = userManager.CreateAsync(administrator, "Admin123").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(administrator, "Administrator").Wait();
                }
            }
        }
    }
}
