using H5ServerSide_ToDoList.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace H5ServerSide_ToDoList.Data
{
    public class DataDBContext(DbContextOptions<DataDBContext> options) : DbContext(options)
    {
        public DbSet<CPR> CPRs { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
