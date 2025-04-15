using System;
using System.ComponentModel.DataAnnotations;
namespace StudySync.Models
{
    public class Subtask
    {

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; } = false;

        // Foreign key to link to a parent task
        public int? TaskId { get; set; }
        public TaskItem Task { get; set; }
    }

}
