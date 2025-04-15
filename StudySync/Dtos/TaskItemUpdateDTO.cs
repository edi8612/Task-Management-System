using System.ComponentModel.DataAnnotations;

namespace StudySync.Dtos
{
    public class TaskItemUpdateDTO
    {
        //[Required]
        //public int Id { get; set; } // Task ID for identification
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "DueDate is required")]
        public DateTime DueDate { get; set; }
        [Required(ErrorMessage = "Priority is required")]
        public string Priority { get; set; }
        public int? CategoryId { get; set; }
    }
}
