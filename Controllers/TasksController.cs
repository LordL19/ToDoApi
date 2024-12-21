using ToDoApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Data;
using TaskEntity = ToDoApi.Models.Domain.Task;
using ToDoApi.Repositories.Interface;

namespace ToDoApi.Controllers
{
    // https://localhost:xxxx/api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository taskRepository;
        public TasksController(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;

        }
        //CREATE: POST api/Taks
        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskRequestDto request)
        {
            // Map DTO to Domain Model
            var task = new TaskEntity
            {
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                IsCompleted = request.IsCompleted

            };

            var createdTask = await taskRepository.CreateAsync(task);

            // Domain model to DTO
            var response = new TaskDto
            {
                TaskId = task.TaskId,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                IsCompleted = task.IsCompleted
            };

            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.TaskId }, response);
        }
        // READ: GET API/TASKS
        [HttpGet]
        public async Task<IActionResult>GetAllTasks()
        {
            var tasks = await taskRepository.GetAllAsync();
            var response = tasks.Select(task => new TaskDto
            {
                TaskId = task.TaskId,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                IsCompleted = task.IsCompleted
            });

            return Ok(response);
        }

        //READ GET api/Tasks/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTaskById (Guid id)
        {
            var task = await taskRepository.GetByIdAsync(id);
            if (task == null) return NotFound();

            var response = new TaskDto
            {
                TaskId = task.TaskId,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                IsCompleted = task.IsCompleted
            };
            return Ok(response);
        }
        // UPDATE: PUT api/Tasks/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdatedTask (Guid id, CreateTaskRequestDto request)
        {
            var task = new TaskEntity
            {
                TaskId = id,
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                IsCompleted = request.IsCompleted
            };

            var updatedTask = await taskRepository.UpdateAsync(task);
            if (updatedTask == null) return NotFound();

            var response = new TaskDto
            {
                TaskId = updatedTask.TaskId,
                Title = updatedTask.Title,
                Description = updatedTask.Description,
                DueDate = updatedTask.DueDate,
                IsCompleted = updatedTask.IsCompleted
            };

            return Ok(response);
        }
        // DELETE: api/Tasks/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletedTask(Guid id)
        {
            var deleted = await taskRepository.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }


    }
}
