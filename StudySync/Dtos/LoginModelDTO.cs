using System.ComponentModel.DataAnnotations;

namespace StudySync.Dtos
{
    public class LoginModelDTO
    {

        [Required(ErrorMessage = "Username or Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
