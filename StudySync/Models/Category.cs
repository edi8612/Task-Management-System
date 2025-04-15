using System;
using System.ComponentModel.DataAnnotations;

namespace StudySync.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } // "Homework", "Projects", "Exams"

        // One category can be linked to many tasks
        public List<TaskItem> Tasks { get; set; } = new();
    }

}

