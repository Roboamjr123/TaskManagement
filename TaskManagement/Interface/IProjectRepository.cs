using TaskManagement.Models;

namespace TaskManagement.Interface
{
    public interface IProjectRepository
    {
        // Project methods
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task AddProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(int id);
    }
}