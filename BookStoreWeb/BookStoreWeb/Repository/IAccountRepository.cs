using BookStoreWeb.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreWeb.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserVM model);
        Task<SignInResult> UserSignInAsync(SignInUserVM model);
        Task UserSignOutAsync();
        Task<IdentityResult> UserChangePassword(UserChangePasswordVM model);
        Task<List<IdentityRole>> GetAllRoles();
    }
}