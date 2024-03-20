using Microsoft.AspNetCore.Identity;

namespace H5ServerSide_ToDoList.Codes
{
    public class RoleHandler
    {
        public  async Task CreteUserRole(string user, string role, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<Data.ApplicationUser>>();


            bool userCheckRole = await roleManager.RoleExistsAsync(role);

            if (!userCheckRole) 
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }

            Data.ApplicationUser identityUser = await userManager.FindByEmailAsync(user);

            await userManager.AddToRoleAsync(identityUser, role);
        }
    }
}
