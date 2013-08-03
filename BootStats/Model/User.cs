using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootStats.Model
{
    public class User : Model
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public int AuthLevel { get; set; }

        public User()
        {
            Username = "";
            Password = "";
            AuthLevel = 0;
        }

        public User(string username, string password, int authlevel)
        {
            Username = username;
            Password = password;
            AuthLevel = authlevel;
        }
       

        public override string AsJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }


        public bool Login(string username, string password)
        {
            //TODO: Hash and check and stuff
            return Username.Equals(username) && Password.Equals(password);
        }

        private string Hash(string hash)
        {
            return hash;
        }
    }
}
