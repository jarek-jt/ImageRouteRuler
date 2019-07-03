using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRouteRuler
{
    public class Serializer
    {
        public static  void Save<T>(string path, IEnumerable<T> obj)
        {
            JsonSerializer serializer = new JsonSerializer();
           
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, obj);
            }
        }

        public static IEnumerable<T> Load<T>(string path)
        {
            string json = File.ReadAllText(path);

            IEnumerable<T> route = JsonConvert.DeserializeObject<IEnumerable<T>>(json);

            return route;
        }

    }
}
