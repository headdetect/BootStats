using BootStats.Controller;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebSharp;
using WebSharp.Handlers;
using WebSharp.MVC;
using WebSharp.Routing;

namespace BootStats
{
    class Program
    {
        static void Main(string[] args)
        {

            var httpd = new HttpServer();
            var router = new HttpRouter();

            httpd.Request = router.Route;
            httpd.LogRequests = true;

            var staticResources = new StaticContentHandler("./Static");
            router.AddRoute(new StaticContentRoute(staticResources));

            var mvc = new MvcRouter();
            mvc.RegisterController(new IndexController());
            mvc.AddRoute("Index", "{action}", new { controller = "Index", action = "Index" });
            router.AddRoute(mvc);

            httpd.Start(new IPEndPoint(IPAddress.Any, 8080));

            Console.WriteLine("Server started on port 8080");

            try
            {
                Process.Start("http://localhost:8080");
            }
            catch { }

            Console.WriteLine("Type 'quit' to exit, or 'help' for help.");
            string command = null;
            while (command != "quit")
            {
                command = Console.ReadLine();
                HandleCommand(command);
            }
        }

        public static void HandleCommand(string command)
        {
            var name = command;
            var parameters = string.Empty;
            if (name.Contains(" "))
            {
                parameters = name.Substring(name.IndexOf(' ') + 1);
                name = name.Remove(name.IndexOf(' '));
            }
            switch (name.ToUpper())
            {
                default: break;
            }
        }
    }
}
