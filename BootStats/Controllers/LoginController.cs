using System;
using BootStats.Model;
using WebSharp;
using WebSharp.MVC;
using System.Linq;

namespace BootStats.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View("Pages/Login.cshtml");
        }

        public ActionResult DoLogin(string username, string password)
        {
            Console.WriteLine("Login Request => {0} {1}", username, password);
            User found = BootStats.Users.FirstOrDefault(user => user.Login(username, password));
            return found != null ? 
                View("/Index", new { uname = username }, HttpStatusCodes.MovedTemp) : 
                View("Pages/Login.cshtml", new { success = false, name = username }, HttpStatusCodes.BadRequest);
        }


    }
}
