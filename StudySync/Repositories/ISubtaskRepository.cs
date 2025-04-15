using StudySync.Models;

namespace StudySync.Repositories;

public interface ISubtaskRepository
{
    Task<IEnumerable<Subtask>> GetAllSubtasksAsync();
    Task<IEnumerable<Subtask>> GetSubtasksByTaskIdAsync(int taskId);
    Task AddSubtaskAsync(Subtask subtask);
    Task UpdateSubtaskAsync(Subtask subtask);
    Task DeleteSubtaskAsync(int id);
    Task<IEnumerable<Subtask>> GetIncompleteSubtasksByTaskIdAsync(int taskId);
}