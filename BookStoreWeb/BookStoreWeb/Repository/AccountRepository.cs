using BookStoreWeb.Data;
using BookStoreWeb.Models;
using BookStoreWeb.Service;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStoreWeb.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userService;
        public AccountRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        //....sign up

        public async Task<IdentityResult> CreateUserAsync(SignUpUserVM model)
        {
            var user = new ApplicationUser
            {
                Email = model.email,
                UserName = model.email,
                firstName = model.firstName.Trim().ToLower(),
                lastName = model.lastName.Trim().ToLower(),
                fullName = model.firstName.Trim().ToLower() + " " + model.lastName.Trim().ToLower(),
                dateOfBirth = model.dateOfBirth
            };
            return await _userManager.CreateAsync(user,model.password);
        }

        //......sign in
        public async Task<SignInResult> UserSignInAsync(SignInUserVM model)
        {
            return await _signInManager.PasswordSignInAsync(model.email,model.password,model.rememberMe,false);
        }

        //......sign out
        public async Task UserSignOutAsync()
        {
             await _signInManager.SignOutAsync();
        }

        //....change password
        public async Task<IdentityResult> UserChangePassword(UserChangePasswordVM model)
        {
            var user = await _userManager.FindByIdAsync(_userService.GetUserId());
            return await _userManager.ChangePasswordAsync(user,model.currentPassword,model.newPassword);
        }
    }
}
