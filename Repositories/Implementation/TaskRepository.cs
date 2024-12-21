using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using ToDoApi.Data;
using ToDoApi.Models.Domain;
using TaskEntity = ToDoApi.Models.Domain.Task;
using ToDoApi.Repositories.Interface;

namespace ToDoApi.Repositories.Implementation
{
    public class TaskRepository: ITaskRepository
    {
        private readonly ApplicationDbContext dbContext;
        public TaskRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<TaskEntity> CreateAsync(TaskEntity task)
        {
            await dbContext.Tasks.AddAsync(task);
            await dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<IEnumerable<TaskEntity>> GetAllAsync()
        {
            return await dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskEntity> GetByIdAsync(Guid id)
        {
            return await dbContext.Tasks.FirstOrDefaultAsync(t => t.TaskId == id);
        }

        public async Task<TaskEntity>UpdateAsync(TaskEntity task)
        {
            var existingTask = await dbContext.Tasks.FindAsync(task.TaskId);
            if (existingTask == null) return null;

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.DueDate = task.DueDate;
            existingTask.IsCompleted =  task.IsCompleted;

            await dbContext.SaveChangesAsync();
            return existingTask;


        }

        public async Task <bool> DeleteAsync (Guid id)
        {
            var task    = await dbContext.Tasks.FindAsync(id);
            if (task == null) return false;

            dbContext.Tasks.Remove(task);
            await dbContext.SaveChangesAsync();
            return true;
        }

    }
}
