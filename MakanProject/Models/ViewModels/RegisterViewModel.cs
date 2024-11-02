using System.ComponentModel.DataAnnotations;

namespace MakanProject.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Key]
        public int UserId { get; set; } 
        [Required(ErrorMessage = "Enter Your Email")]
        [EmailAddress]
        
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Confirm Email")]
        [Compare("Email", ErrorMessage = "Confirm Didn't Match")]
        [EmailAddress]
        public string ConfirmEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Enter Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm Didn't Match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string Mobile { get; set; }
    }
}
