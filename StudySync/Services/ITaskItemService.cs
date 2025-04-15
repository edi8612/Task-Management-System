
using StudySync.Dtos;
using StudySync.Models;

namespace StudySync.Services
{
    public interface ITaskItemService
    {
        // Basic CRUD operations (initially pass-through to repository)
        Task<TaskItemDTO> GetTaskByIdAsync(int id);
        Task<IEnumerable<TaskItemDTO>> GetAllTasksAsync();
        Task<TaskItemDTO> CreateTaskAsync(TaskItemCreateDTO task);
        Task UpdateTaskAsync(TaskItemUpdateDTO task, int id);
        Task DeleteTaskAsync(int id);
        
          // Business logic method
        Task<IEnumerable<TaskItemDTO>> GetIncompleteTasksAsync();
        Task<bool> ToggleTaskCompletionAsync(int id);

        // New methods
        Task<IEnumerable<TaskItemDTO>> GetTasksByPriorityAsync(string priority);
        Task<IEnumerable<TaskItemDTO>> GetUpcomingTasksAsync(int days);
        Task AssignTaskToUserAsync(int taskId, int userId);
    }
}