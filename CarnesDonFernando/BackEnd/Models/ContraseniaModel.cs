using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class ContraseniaModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string OldPassword { get; set; }
    }

}
