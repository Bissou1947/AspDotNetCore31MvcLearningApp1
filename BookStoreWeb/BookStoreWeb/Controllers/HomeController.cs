using Microsoft.AspNetCore.Mvc;

namespace BookStoreWeb.Controllers
{
    public class HomeController: Controller
    {
        public string Index()
        {
            return "Home";
        }
    }
}
