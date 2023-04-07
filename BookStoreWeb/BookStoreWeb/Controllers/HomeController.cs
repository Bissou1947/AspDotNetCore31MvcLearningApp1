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
        public ViewResult AboutUs()
        {
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
