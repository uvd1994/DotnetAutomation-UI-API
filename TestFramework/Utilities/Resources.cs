using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Utilities
{
    public static class Resources
    {
        public static JObject GetConfigData()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = path.Replace("TestProject\\TestProject\\bin\\Debug\\net6.0\\", "TestProject\\TestFramework\\Config\\config.data.json");
            var configData = JsonUtility.ReadJSON(configPath);
            return configData;
        }
    }
}
