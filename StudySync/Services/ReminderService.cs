using StudySync.Models;
using StudySync.Repositories;

namespace StudySync.Services
{
    public class ReminderService : IReminderService
    {
        private readonly IReminderRepository _reminderRepository;

        public ReminderService(IReminderRepository reminderRepository)
        {
            _reminderRepository = reminderRepository;
        }

        public async Task CreateReminderAsync(Reminder reminder)
        {
            await _reminderRepository.AddReminderAsync(reminder);
        }

        public async Task DeleteReminderAsync(int id)
        {
            await _reminderRepository.DeleteReminderAsync(id);
        }

        public async Task<IEnumerable<Reminder>> GetAllRemindersAsync()
        {
            return await _reminderRepository.GetAllRemindersAsync();
        }

        public async Task<Reminder?> GetReminderByIdAsync(int id)
        {
            return await _reminderRepository.GetReminderByIdAsync(id);
        }

        public async Task<IEnumerable<Reminder>> GetUpcomingRemindersAsync()
        {
            return await _reminderRepository.GetUpcomingRemindersAsync();
        }

        public async Task UpdateReminderAsync(Reminder reminder)
        {
            await _reminderRepository.UpdateReminderAsync(reminder);
        }
    }
}
