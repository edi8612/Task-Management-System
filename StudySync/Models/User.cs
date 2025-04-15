using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudySync.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // One user can have multiple tasks
        [JsonIgnore]
        public List<TaskItem> Tasks { get; set; } = new();
    }

}

