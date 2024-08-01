using TaskManagement.Models;

namespace TaskManagement.Interface
{
    public interface IActivityRepository
    {
        // Activity methods
        Task<IEnumerable<Activity>> GetAllActivitiesAsync();
        Task<Activity> GetActivityByIdAsync(int id);
        Task AddActivityAsync(Activity activity);
        Task UpdateActivityAsync(Activity activity);
        Task DeleteActivityAsync(int id);
    }
}
