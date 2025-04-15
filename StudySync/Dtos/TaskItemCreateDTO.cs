using System.ComponentModel.DataAnnotations;

namespace StudySync.Dtos
{
    public class TaskItemCreateDTO
    {
        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "DueDate is required")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Priority is required")]
        public string Priority { get; set; }  // Low, Medium, High

        //[Required(ErrorMessage = "Category ID is required")]
        public int? CategoryId {  get; set; }


        //[Required(ErrorMessage = "User ID is required")]
        //public int UserId { get; set; }
        //public bool IsCompleted { get; set; }








    }
}
