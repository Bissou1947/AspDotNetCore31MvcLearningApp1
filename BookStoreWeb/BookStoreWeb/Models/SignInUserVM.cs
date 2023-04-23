using System.ComponentModel.DataAnnotations;

namespace BookStoreWeb.Models
{
    public class SignInUserVM
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name ="Remember Me")]
        public bool rememberMe { get; set; }
    }
}
