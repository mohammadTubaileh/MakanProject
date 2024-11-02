using System.ComponentModel.DataAnnotations;

namespace MakanProject.Models.ViewModels
{
    public class LoginViewModel
    {
        [Key]
        public int UserId { get; set; } 
        [Required(ErrorMessage = "Enter Email Address")]

        [EmailAddress]

        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Your Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
