using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace H5ServerSide_ToDoList.Data.Models.Entities
{
    public class ToDoItem
    {
        [Key]
        public Guid Id { get; set; }

        public Guid CPRId { get; set; }

        public string Name { get; set; }
    }
}
