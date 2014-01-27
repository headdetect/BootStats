using System;
using BootStats.Model;
using WebSharp;
using WebSharp.MVC;
using System.Linq;
using WebSharp.MVC.Results;

namespace BootStats.Controllers
{
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DoLogin(string username, string password)
        {
            Console.WriteLine("Login Request => {0} {1}", username, password);
            User found = BootStats.Users.FirstOrDefault(user => user.Login(username, password));
            return found != null ? 
                Redirect("Index") :
                View("Index", model: new { success = false, name = username }, status: HttpStatusCode.BadRequest);
        }


    }
}
