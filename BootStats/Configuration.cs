using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using BootStats.Model;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace BootStats
{
    public class Configuration
    {
        public List<User> Users { get; set; }

        public string BindingAddress { get; set; }

        public int BindingPort { get; set; }

        public bool Log { get; set; }

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>
        /// The file path.
        /// </value>
        [JsonIgnore]
        public string FilePath { get; set; }


        public Configuration()
        {
            Users = new List<User> { new User("admin", "password", 1) };
            BindingAddress = "0.0.0.0";
            BindingPort = 8080;
            Log = true;
        }

        /// <summary>
        /// Loads the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        public void Load(string file)
        {

            FilePath = file;
            Reload();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            if (FilePath == null) return;

            var lines = JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);

            if (!File.Exists(FilePath))
            {
                using (var notused = File.CreateText(FilePath)) { }
            }

            File.WriteAllText(FilePath, lines);
        }

        /// <summary>
        /// Reloads this instance.
        /// </summary>
        public void Reload()
        {
            if (FilePath == null) return;
            if (!File.Exists(FilePath))
            {
                using (var notused = File.CreateText(FilePath)) { }
            }

            using (var reader = File.OpenText(FilePath))
            {
                string read = reader.ReadToEnd();
                if(string.IsNullOrWhiteSpace(read)) return;
                JsonConvert.PopulateObject(read, this);
            }
        }

    }
}