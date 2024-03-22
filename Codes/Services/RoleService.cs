using Microsoft.AspNetCore.Identity;
using System.Data;

namespace H5ServerSide_ToDoList.Codes.Services
{
    public class RoleService : IRoleService
    {
        private readonly string role = "Admin";

        public async Task ToggleAdmin(string userEmail, IServiceProvider serviceProvider)
        {
          
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<Data.ApplicationUser>>();


            bool userCheckRole = await roleManager.RoleExistsAsync(role);

            if (!userCheckRole)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }

            Data.ApplicationUser identityUser = await userManager.FindByEmailAsync(userEmail);

            var userHasRole = await userManager.IsInRoleAsync(identityUser, role);

            if(userHasRole) 
            {
                await userManager.RemoveFromRoleAsync(identityUser, role);
            }
            else
            {
                await userManager.AddToRoleAsync(identityUser, role);
            }
        }

        public async Task<bool> IsAdmin(string userEmail, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<Data.ApplicationUser>>();

            Data.ApplicationUser identityUser = await userManager.FindByEmailAsync(userEmail);

            return await userManager.IsInRoleAsync(identityUser, role);
        }
    }
}
