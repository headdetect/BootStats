using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSharp.MVC;
using System.Threading.Tasks;

namespace BootStats.Controllers
{
    class IndexController : WebSharp.MVC.Controller
    {
        public ActionResult Index()
        {
            return ViewOk("Pages/Index.cshtml");
        }
    }
}
