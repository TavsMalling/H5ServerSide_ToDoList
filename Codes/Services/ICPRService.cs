using System.Runtime.CompilerServices;

namespace H5ServerSide_ToDoList.Codes.Services
{
    public interface ICPRService
    {
        Task AddCPRToUser(string CPR);
        Task AddNameToUser(string CPR);
    }
}
