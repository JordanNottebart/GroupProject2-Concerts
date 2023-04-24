using CENV_JMH.DO;
using Microsoft.AspNetCore.Identity;

namespace CENV.UI.Web.Helper
{
    public class SeedDataBaseHelper 
    {
        public static async Task Seed(IServiceProvider service)
        {
            //Seed Roles
            var userManager = service.GetService<UserManager<IdentityUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            //add two roles
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));


            // creating admin


            var user = new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                PhoneNumber = "0123456789",
                
                
            };
            var userInDb = await userManager.FindByEmailAsync(user.Email);
            if (userInDb == null)
            {
                await userManager.CreateAsync(user, "Testing*123");
                await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
            }

        }
    }
}
