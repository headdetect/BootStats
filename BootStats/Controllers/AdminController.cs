using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSharp.MVC;
using System.Threading.Tasks;
using WebSharp.MVC.Results;

namespace BootStats.Controllers
{
    class AdminController : WebSharp.MVC.Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
