using System;
using System.ComponentModel.DataAnnotations;

namespace StudySync.Models
{
    public class Reminder
    {
        [Key]
        public int Id { get; set; }
        public DateTime ReminderDateTime { get; set; }

        // Foreign key to link to a task
        public int TaskId { get; set; }
        public TaskItem Task { get; set; }
    }

}

