using System.ComponentModel.DataAnnotations;

namespace StudySync.Dtos
{
    public class CategoryCreateDTO
    {
<<<<<<< HEAD
        [Required(ErrorMessage = "Name is required")]
=======

        [Required(ErrorMessage ="Category is required")]
>>>>>>> 2f844f17d9af319df8d5f522749a05fd978618a5
        public string Name { get; set; }
    }
}
