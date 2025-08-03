using Microsoft.AspNetCore.Mvc;

namespace NurseryLinkProject.MVC.Controllers
{
    public class IdentityController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Login()
        //{

        //}

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Register()
        //{

        //}
    }
}
