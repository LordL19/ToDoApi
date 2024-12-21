using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApi.Models.Domain
{
    public class Task
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }
        

    }
}
