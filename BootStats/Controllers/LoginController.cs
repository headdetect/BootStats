using System;
using BootStats.Model;
using WebSharp.MVC;
using System.Linq;

namespace BootStats.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return ViewOk("Pages/Login.cshtml");
        }

        public ActionResult DoLogin(string username, string password)
        {
            Console.WriteLine("Login Request => {0} {1}", username, password);
            User found = BootStats.Users.FirstOrDefault(user => user.Login(username, password));
            if (found != null)
                return ViewRedirect("/Index","Pages/Index.cshtml",  new {uname = username});
            return ViewBadRequest("Pages/Login.cshtml", new { success = false, name = username });
        }


    }
}
