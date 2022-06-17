using CRUDApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUDApp.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private AccountService accountService;

        public AuthController(AccountService _accountService)
        {
            accountService = _accountService;
        }

        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string username, string password)
        {
            var account = accountService.Login(username, password);
            if (account != null)
            {
                HttpContext.Session.SetString("username", username);
                // return RedirectToAction("Home/Index");
                return RedirectToAction("Welcome");

            } else
            {
                ViewBag.msg = "Username / Password Salah";
                return View("Index");
            }
        }

        [Route("welcome")]
        public IActionResult Welcome()
        {
            ViewBag.username = HttpContext.Session.GetString("username");            
            return View();
        }

        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("index");
        }
    }
}