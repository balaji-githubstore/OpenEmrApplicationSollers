using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenEmrApplication.Utilities
{
    class JsonUtils
    {
        public static string GetValue(string fileDetail,string key)
        {
            StreamReader reader = new StreamReader(fileDetail);
            dynamic json = JsonConvert.DeserializeObject(reader.ReadToEnd());
            return Convert.ToString(json[key]);
        }
    }
}
