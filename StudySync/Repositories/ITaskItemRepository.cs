using System;
using StudySync.Models;

namespace StudySync.Repositories
{
    public interface ITaskItemRepository
    {
        Task<TaskItem> GetTaskByIdAsync(int id);
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        Task AddTaskAsync(TaskItem task);
        Task UpdateTaskAsync(TaskItem task);
        Task DeleteTaskAsync(int id);
        Task<IEnumerable<TaskItem>> GetIncompleteTasksAsync();
    }
}

