using System;
using System.ComponentModel.DataAnnotations;

namespace StudySync.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }  // Low, Medium, High
        public bool IsCompleted { get; set; } = false;

        // Foreign key to link tasks to users
        public int UserId { get; set; }
        public User User { get; set; }

        // Foreign key for categories
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // A task can have multiple subtasks
        public List<Subtask> Subtasks { get; set; } = new();
    }

}

