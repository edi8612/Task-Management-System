using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudySync.Data;
using StudySync.Models;

namespace StudySync.Repositories
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly ApplicationDbContext _context;

        public ReminderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reminder>> GetAllRemindersAsync()
        {
            return await _context.Reminders.ToListAsync();
        }

        public async Task<Reminder?> GetReminderByIdAsync(int id)
        {
            return await _context.Reminders.FindAsync(id);
        }

        public async Task AddReminderAsync(Reminder reminder)
        {
            await _context.Reminders.AddAsync(reminder);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReminderAsync(Reminder reminder)
        {
            _context.Reminders.Update(reminder);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReminderAsync(int id)
        {
            var reminder = await GetReminderByIdAsync(id);
            if (reminder != null)
            {
                _context.Reminders.Remove(reminder);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Reminder>> GetUpcomingRemindersAsync()
        {
            var now = DateTime.Now;
            var next24Hours = now.AddHours(24);

            return await _context.Reminders
                .Where(r => r.ReminderDateTime >= now && r.ReminderDateTime <= next24Hours)
                .ToListAsync();
        }
    }
}