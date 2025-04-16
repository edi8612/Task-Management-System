using System.ComponentModel.DataAnnotations;

namespace StudySync.Dtos
{
    public class CategoryCreateDTO
    {

        [Required(ErrorMessage ="Category is required")]
        public string Name { get; set; }
    }
}
