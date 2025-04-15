using StudySync.Models;
using StudySync.Repositories;

namespace StudySync.Services
{
    public class SubtaskService : ISubtaskService
    {
        private readonly ISubtaskRepository _subtaskRepository;

        public SubtaskService(ISubtaskRepository subtaskRepository)
        {
            _subtaskRepository = subtaskRepository;
        }

        public async Task CreateSubtaskAsync(Subtask subtask)
        {

            await _subtaskRepository.AddSubtaskAsync(subtask);

        }

        public async Task DeleteSubtaskAsync(int id)
        {
            await _subtaskRepository.DeleteSubtaskAsync(id);
        }

        public async Task<IEnumerable<Subtask>> GetAllSubtasksAsync()
        {
            return await _subtaskRepository.GetAllSubtasksAsync();
        }

        public async Task<IEnumerable<Subtask>> GetIncompleteSubtasksByTaskIdAsync(int taskId)
        {
            return await _subtaskRepository.GetIncompleteSubtasksByTaskIdAsync(taskId);
        }

        public async Task<IEnumerable<Subtask?>> GetSubtaskByTaskIdAsync(int taskId)
        {
            return await _subtaskRepository.GetSubtasksByTaskIdAsync(taskId);
        }

        public async Task UpdateSubtaskAsync(Subtask subtask)
        {
            await _subtaskRepository.UpdateSubtaskAsync(subtask);
        }
    }
}
