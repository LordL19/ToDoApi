namespace ToDoApi.Models.DTO
{
    public class CreateTaskRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }

    }
}
