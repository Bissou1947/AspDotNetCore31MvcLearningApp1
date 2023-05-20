using BookStoreWeb.Models;
using BookStoreWeb.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStoreWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _iAccountRepository;

        public AccountController(IAccountRepository iAccountRepository)
        {
            _iAccountRepository = iAccountRepository;
        }

        //..................................................................//


        [HttpGet("Sign-Up")]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost("Sign-Up")]
        public async Task<IActionResult> SignUp(SignUpUserVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _iAccountRepository.CreateUserAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(model);
                }
            }
            ModelState.AddModelError("", "Faild: invalid data");
            return View(model);
        }


        //.................................................................//

        [HttpGet("Sign-In")]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost("Sign-In")]
        public async Task<IActionResult> SignIn(SignInUserVM model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                var result = await _iAccountRepository.UserSignInAsync(model);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl.Trim()) && !string.IsNullOrWhiteSpace(returnUrl.Trim()))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "Faild: Account is LockedOut");
                    return View(model);
                }
            }
            ModelState.AddModelError("", "Faild: invalid data");
            return View(model);
        }

        //..........................................................................//


        [Route("Sign-Out")]
        public async Task<IActionResult> SignOut()
        {
            await _iAccountRepository.UserSignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        //..........................................................................//

        [HttpGet("Change-Password")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost("Change-Password")]
        public async Task<IActionResult> ChangePassword(UserChangePasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _iAccountRepository.UserChangePassword(model);
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(model);
                }
            }
            ModelState.AddModelError("", "Faild: invalid data");
            return View(model);
        }

        //..........roles........................................................//
        [Route("All-Roles")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAllRoles()
        {
            return View(await _iAccountRepository.GetAllRoles());
        }

    }
}
