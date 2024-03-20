
using H5ServerSide_ToDoList.Data;
using H5ServerSide_ToDoList.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace H5ServerSide_ToDoList.Codes.Services
{
    public class CPRService : ICPRService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly DataDBContext _dataDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public CPRService(ApplicationDbContext applicationDbContext, DataDBContext dataDBContext, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _dataDbContext = dataDBContext;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task AddCPRToUser(string CPR)
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await _userManager.FindByEmailAsync(userName.ToUpper());

            if(user != null)
            {
                CPR tempCpr = new() { CPR_number = CPR, Name = user.UserName, Id = Guid.Parse(user.Id) };
                _dataDbContext.CPRs.Update(tempCpr);
                await _dataDbContext.SaveChangesAsync();
            }
            else
            {
                throw new NotImplementedException("User not found.");
            }

        }

        public Task AddNameToUser(string CPR)
        {
            throw new NotImplementedException();
        }
    }
}
