using Microsoft.AspNetCore.Identity;
using System;

namespace BookStoreWeb.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public DateTime? dateOfBirth { get; set; }
    }
}
