using Microsoft.AspNetCore.Mvc;
using StudySync.Models;
using StudySync.Repositories;

namespace StudySync.Controllers;

[ApiController]
[Route("[controller]")]
public class ReminderController : ControllerBase
{
    private readonly IReminderRepository _reminderRepository;

    public ReminderController(IReminderRepository reminderRepository)
    {
        _reminderRepository = reminderRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reminder>>> GetReminders()
    {
        var reminders = await _reminderRepository.GetAllRemindersAsync();
        return Ok(reminders);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Reminder>> GetReminder(int id)
    {
        var reminder = await _reminderRepository.GetReminderByIdAsync(id);
        if (reminder == null)
        {
            return NotFound();
        }
        return Ok(reminder);
    }
    
}