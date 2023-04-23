using System.ComponentModel.DataAnnotations;

namespace BookStoreWeb.Models
{
    public class UserChangePasswordVM
    {
        [Required]
        [Display(Name = "Current Password")]
        [DataType(DataType.Password)]
        public string currentPassword { get; set; }
        [Required]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        [Compare("confirmNewPassword")]
        public string newPassword { get; set; }
        [Required]
        [Display(Name = "Confirm New Password")]
        [DataType(DataType.Password)]
        public string confirmNewPassword { get; set; }
    }
}
