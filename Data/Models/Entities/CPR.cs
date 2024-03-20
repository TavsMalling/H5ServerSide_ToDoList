namespace H5ServerSide_ToDoList.Data.Models.Entities
{
    public class CPR
    {
        public Guid Id { get; set; }

        public required string CPR_number { get; set; }

        public required string Name { get; set; }
    }
}
