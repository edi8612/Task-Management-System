using System.ComponentModel.DataAnnotations;

namespace StudySync.Dtos
{
    public class CategoryCreateDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
