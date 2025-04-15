using StudySync.Models;

namespace StudySync.Services
{
    public interface IReminderService
    {
        public Task <IEnumerable<Reminder>> GetAllRemindersAsync();
        public Task<Reminder?> GetReminderByIdAsync(int id);
        public Task CreateReminderAsync(Reminder reminder);
        public Task UpdateReminderAsync(Reminder reminder);
        public Task DeleteReminderAsync(int id);
        public Task<IEnumerable<Reminder>> GetUpcomingRemindersAsync();
    }





}

