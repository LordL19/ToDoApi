namespace ToDoApi.Models.DTO
{
    public class TaskDto
    {
        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }

    }
}
