using StudySync.Models;

namespace StudySync.Services
{
    public interface ISubtaskService
    {
        public Task<IEnumerable<Subtask>> GetAllSubtasksAsync();
        public Task<IEnumerable<Subtask>> GetSubtaskByTaskIdAsync(int id);
        public Task CreateSubtaskAsync(Subtask subtask);
        public Task UpdateSubtaskAsync(Subtask subtask);
        public Task DeleteSubtaskAsync(int id);


        public Task<IEnumerable<Subtask>> GetIncompleteSubtasksByTaskIdAsync(int taskId);





    }
}
