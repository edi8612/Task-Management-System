using StudySync.Models;

namespace StudySync.Repositories;

public interface IReminderRepository
{
    Task<IEnumerable<Reminder>> GetAllRemindersAsync();
    Task<Reminder?> GetReminderByIdAsync(int id);
    Task AddReminderAsync(Reminder reminder);
    Task UpdateReminderAsync(Reminder reminder);
    Task DeleteReminderAsync(int id);
    Task<IEnumerable<Reminder>> GetUpcomingRemindersAsync();
}