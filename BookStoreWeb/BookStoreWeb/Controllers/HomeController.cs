using BookStoreWeb.Models;
using BookStoreWeb.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace BookStoreWeb.Controllers
{
    public class HomeController: Controller
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;
        public readonly IEmailService _emailService;

        public HomeController(IConfiguration config, IUserService userService, IEmailService emailService)
        {
            _config = config;
            _userService = userService;
            _emailService = emailService;
        }
        public async Task<ViewResult> Index()
        {
            //..............................//
            TestMailOptionsVM testMailOptionsVM = new TestMailOptionsVM
            {
                mailToAddresses = new List<string> { "bassil_1947@hotmail.com" },
                placeHolder = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("{{clientName}}" ,"Bassil")
                }
                
            };
            await _emailService.SendTestMail(testMailOptionsVM);
            //...............................//

            var signInUserId = _userService.GetUserId();
            var isUserSignIn = _userService.IsUserAuthenticated();

            //...............................//
            var key1 = _config["TestObj:Key1"]; //...read from appsettings.json
            var Key3Key1 = _config["TestObj:Key3:Key3Key1"]; //...read from appsettings.json

            //..to read anything else from string
            var testNewBookAlert = _config.GetValue<bool>("TestDisplayNewBookAlertInServerSideCode");

            //....to read configration from appsettings.json and bind it to model class
            //...see TestBindConfigurationToObject class , and appsettings.json
            TestBindConfigurationToObject obj = new TestBindConfigurationToObject();
            _config.Bind("TestAlertInClientSideCode", obj);
            var check = obj.NewBookAlert;
            var alert = obj.BookAlert;

            //..for smtp mail
            SmtpConfigVM smtpConfigVM = new SmtpConfigVM(); 

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
