using BookStoreWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookStoreWeb.Claims
{
    public class SignInUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public SignInUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options)
            : base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var userIdentity = await base.GenerateClaimsAsync(user);
            userIdentity.AddClaim(new Claim("userFullName", user.fullName ?? string.Empty));
            return userIdentity;
        }
    }
}
