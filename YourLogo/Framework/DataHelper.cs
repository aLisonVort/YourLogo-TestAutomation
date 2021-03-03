using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLogo.Framework
{
    public static class DataHelper
    {
        public static string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public  static T DeserializeJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
