using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace BookStoreWeb.Controllers
{
    public class HomeController: Controller
    {
        public ViewResult Index()
        {
            return View();
        }
        [Route("About-Us")]
        public ViewResult AboutUs()
        {
            return View();
        }
        [Route("Contact-Us")]
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
