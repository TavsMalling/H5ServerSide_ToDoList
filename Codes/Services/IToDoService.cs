using H5ServerSide_ToDoList.Data;
using H5ServerSide_ToDoList.Data.Models.Entities;

namespace H5ServerSide_ToDoList.Codes.Services
{
    public interface IToDoService
    {
        Task AddToDoItem(string toDoName, Guid userId);

        Task<List<ToDoItem>> GetToDoItems(Guid userId);

        Task RemoveToDoItem(Guid toDoId);

        Task RemoveToDoItemList(Guid userId);
    }
}
