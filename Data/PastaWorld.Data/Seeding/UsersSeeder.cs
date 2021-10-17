namespace PastaWorld.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using PastaWorld.Common;
    using PastaWorld.Data;
    using PastaWorld.Data.Common.Repositories;
    using PastaWorld.Data.Models;
    using PastaWorld.Data.Seeding;


    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedUserAsync(userManager, "pastaworld@abv.bg");
            await SeedUserAsync(userManager, "tzl_bul@yahoo.com");
        }

        private static async Task SeedUserAsync(UserManager<ApplicationUser> userManager, string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                var appUser = new ApplicationUser();
                appUser.UserName = userName;
                appUser.Email = userName;

                IdentityResult result = new IdentityResult();

                if (userName == "pastaworld@abv.bg")
                {
                    result = userManager.CreateAsync(appUser, "pasta#18boss").Result;
                }
                else if (userName == "tzl_bul@yahoo.com")
                {
                    result = userManager.CreateAsync(appUser, "trqvna@83da").Result;
                }


                if (result.Succeeded)
                {
                    if (userName == "pastaworld@abv.bg" || userName == "tzl_bul@yahoo.com")
                    {
                        userManager.AddToRoleAsync(appUser, GlobalConstants.AdministratorRoleName).Wait();
                    }
                }
            }
        }
    }
}