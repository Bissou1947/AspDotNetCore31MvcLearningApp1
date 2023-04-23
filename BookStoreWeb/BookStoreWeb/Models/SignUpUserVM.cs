using System;
using System.ComponentModel.DataAnnotations;

namespace BookStoreWeb.Models
{
    public class SignUpUserVM
    {
        [Required]
        [Display(Name ="Email")]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Compare("confirmPassword")]
        public string password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        public string fullName { get; set; }
        [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime? dateOfBirth { get; set; }
    }
}
