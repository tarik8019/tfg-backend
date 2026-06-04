using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.DTOs.UserDTOs
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Field required: email")]
        public string Email { get; set; }  = string.Empty;

        [Required(ErrorMessage = "Field required: Password")]      
        public string Password { get; set; } = string.Empty;


    }
}
