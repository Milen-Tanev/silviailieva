namespace SilviaIlieva.Data
{
    using Microsoft.AspNetCore.Identity;
    using SilviaIlieva.Data.Models;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

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

        public static void SeedIllustrations(SilviaIlievaDbContext dbContext)
        {
            var illustrationsUrl = @"..\..\src\img-ill";
            var illustrations = new List<Illustration>();
            string[] images = Directory.GetFiles(illustrationsUrl, "*.jpg");

            //foreach (var item in images)
            //{
            //    var fullPath = 

            //    var img = new Illustration()
            //    {
            //        Name = item.Trim();
            //    };
            //}
        }
    }
}
