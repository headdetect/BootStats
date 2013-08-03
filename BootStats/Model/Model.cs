using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootStats.Model
{
    public abstract class Model
    {
        public abstract string AsJson();
        public static T FromJson<T>(string json) where T : Model
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }

    }
}
