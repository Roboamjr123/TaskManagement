using TaskManagement.Models;

namespace TaskManagement.Interface
{
    public interface ITaskRepository
    {
        // Task methods
        Task<IEnumerable<Tasks>> GetAllTasksAsync();
        Task<Tasks> GetTaskByIdAsync(int id);
        Task AddTaskAsync(Tasks task);
        Task UpdateTaskAsync(Tasks task);
        Task DeleteTaskAsync(int id);
    }
}
