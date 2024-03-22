using H5ServerSide_ToDoList.Data;
using H5ServerSide_ToDoList.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace H5ServerSide_ToDoList.Codes.Services
{
    public class ToDoService : IToDoService
    {
        private readonly DataDBContext _dataDbContext;
        private readonly IAsymmetricEncryptionService _asymmetricEncryptionService;

        public Guid ToDoTest { get; set; }

        public ToDoService(DataDBContext dataDbContext, IAsymmetricEncryptionService asymmetricEncryptionService)
        {
            _dataDbContext = dataDbContext;
            _asymmetricEncryptionService = asymmetricEncryptionService;

        }

        public async Task AddToDoItem(string toDoName, Guid userId)
        {
            var publicKey = await _dataDbContext.CPRs.Where(cpr => cpr.Id == userId).Select(x => x.PublicKey).FirstOrDefaultAsync();

            string encryptedName = _asymmetricEncryptionService.EncryptAsymmetric(toDoName, publicKey);

            var toDoItem = new ToDoItem { CPRId = userId, Name = encryptedName };

            _dataDbContext.ToDoItems.Add(toDoItem);

            await _dataDbContext.SaveChangesAsync();
        }

        public async Task<List<ToDoItem>> GetToDoItems(Guid userId)
        {
            return await _dataDbContext.ToDoItems.Where(item => item.CPRId == userId).ToListAsync();
        }

        public async Task RemoveToDoItem(Guid toDoId)
        {
            var toDoItem = await _dataDbContext.ToDoItems.FirstOrDefaultAsync(item => item.Id == toDoId);

            _dataDbContext.ToDoItems.Remove(toDoItem);

            await _dataDbContext.SaveChangesAsync();
        }

        public async Task RemoveToDoItemList(Guid userId)
        {
            var toDoList = await _dataDbContext.ToDoItems.Where(item => item.CPRId == userId).ToListAsync();

            _dataDbContext.ToDoItems.RemoveRange(toDoList);

            await _dataDbContext.SaveChangesAsync();
        }
    }
}
