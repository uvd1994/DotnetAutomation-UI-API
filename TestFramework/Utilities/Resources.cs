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

        public static string GetPrice(string sizeIndex, string quantity)
        {
            string price = string.Empty;
            if (sizeIndex == "1")
            {
                price = Convert.ToString(3.4 * Convert.ToInt32(quantity));

            }
            else
            {
                price = Convert.ToString(5.6 * Convert.ToInt32(quantity));
            }
            return price;
        }

        public static string GetSize(string sizeIndex)
        {
            string size = string.Empty;
            if (sizeIndex == "1")
            {
                size = "0.330 l";

            }
            else
            {
                size = "0.500 l";
            }
            return size;
        }
    }
}
