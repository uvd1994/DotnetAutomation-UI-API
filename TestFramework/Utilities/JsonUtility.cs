
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestFramework.Utilities
{
    public static class JsonUtility
    {
        public static T ReadJSON<T>(string path)
        {
            string text = File.ReadAllText(path);
            var inputjson = System.Text.Json.JsonSerializer.Deserialize<T>(text);

            return inputjson;
        }
        public static JObject ReadJSON(string path)
        {
            string json = File.ReadAllText(path);
            var o  = JObject.Parse(json);

            return o;
        }
       
    }
}
