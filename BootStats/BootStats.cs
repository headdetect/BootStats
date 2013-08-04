using System.Collections.Generic;
using System.IO;
using BootStats.Controllers;
using System;
using System.Net;
using System.Linq;
using BootStats.Model;
using Newtonsoft.Json;
using WebSharp;
using WebSharp.Handlers;
using WebSharp.MVC;
using WebSharp.Routing;

namespace BootStats
{
    public class BootStats
    {
        public static Dictionary<object, object> Session;

        private static Configuration Config;

        public static List<User> Users;

        static void Main(string[] args)
        {
            SetupConfig();

            // TODO: Set routes via config file
            SetupRoutes();

            SetupInput();

        }

        static void SetupConfig()
        {
            Config = new Configuration();
            Config.Load("config.json");
            Config.Save();
            Users = new List<User>(Config.Users);
        }

        static void SetupRoutes()
        {
            var httpd = new HttpServer();
            var router = new HttpRouter();

            httpd.Request = router.Route;
            httpd.LogRequests = Config.Log;

            var staticResources = new StaticContentHandler("./Static");
            router.AddRoute(new StaticContentRoute(staticResources));

            var mvc = new MvcRouter();

            mvc.RegisterController(new LoginController());
            mvc.RegisterController(new IndexController());

            mvc.AddRoute("Home",  "",         new { controller = "Login", action = "Login" });
            mvc.AddRoute("Login", "{action}", new { controller = "Login", action = "Login" });
            mvc.AddRoute("Index", "{action}", new { controller = "Index", action = "Index" });

            router.AddRoute(mvc);

            httpd.Start(new IPEndPoint(IPAddress.Parse(Config.BindingAddress), Config.BindingPort));

            Console.WriteLine("Server started on port " + Config.BindingPort);
        }

        static void SetupInput()
        {
            Console.WriteLine("Type 'quit' to exit, Type 'createuser' to make a new user.");
            string command = null;
            while (command != "quit")
            {
                var readLine = Console.ReadLine();
                if (readLine != null) command = readLine.ToLower();

                var parameters = string.Empty;
                if (command.Contains(" "))
                {
                    parameters = command.Substring(command.IndexOf(' ') + 1);
                    command = command.Remove(command.IndexOf(' '));
                }

                switch (command)
                {
                    case "createuser":
                        string[] split = parameters.Split(' ');
                        if (split.Length != 3)
                        {
                            Console.WriteLine("createuser <string:username> <string:password> <integer:authlevel>");
                            break;
                        }

                        string username = split[0];
                        string password = split[1];
                        int authLevel = split[2].AsPrimitive<int>();

                        User mUser = new User(username, password, authLevel);
                        if (Users.Any(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
                            Console.WriteLine("User already exists");
                        else
                        {
                            Users.Add(mUser);
                            Config.Save();
                            Console.WriteLine("User \"" + username + "\" successfully added!");

                        }
                        break;
                }
            }
        }
    }
}
