using Microsoft.AspNetCore.Mvc;

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
    }
}
