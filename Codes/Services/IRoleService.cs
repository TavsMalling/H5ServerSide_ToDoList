namespace H5ServerSide_ToDoList.Codes.Services
{
    public interface IRoleService
    {
        Task ToggleAdmin(string userEmail, IServiceProvider serviceProvider);

        Task<bool> IsAdmin(string userEmail, IServiceProvider serviceProvider);
    }
}
