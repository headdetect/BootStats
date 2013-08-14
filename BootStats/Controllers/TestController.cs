using WebSharp;
using WebSharp.MVC;
using WebSharp.MVC.Results;

namespace BootStats.Controllers
{
    public class TestController : Controller
    {

        public ActionResult TestRedirect()
        {
            return Redirect("/Login");
        }

    }
}
