using TaskEntity = ToDoApi.Models.Domain.Task;
namespace ToDoApi.Repositories.Interface
{
    public interface ITaskRepository
    {
        Task<TaskEntity> CreateAsync(TaskEntity task);
        Task<IEnumerable<TaskEntity>> GetAllAsync(); //

        Task<TaskEntity> GetByIdAsync(Guid id); //
        Task<TaskEntity> UpdateAsync(TaskEntity task); //

        Task<bool> DeleteAsync (Guid id); //
    }
}
