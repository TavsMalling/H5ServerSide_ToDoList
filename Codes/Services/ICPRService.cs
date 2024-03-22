using H5ServerSide_ToDoList.Data;
using System.Runtime.CompilerServices;

namespace H5ServerSide_ToDoList.Codes.Services
{
    public interface ICPRService
    {
        Task AddCPR(ApplicationUser user, string cpr);

        Task<bool> CPRExist(ApplicationUser user);

        Task<bool> ValidateCPR(ApplicationUser user, string CprString);
    }
}
