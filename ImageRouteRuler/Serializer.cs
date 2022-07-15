using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ImageRouteRuler
{
    public class Serializer
    {
        public static void Save<T>(string path, IEnumerable<T> obj)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, obj);
            }
        }

        public static IEnumerable<T> Load<T>(string path)
        {
            var json = File.ReadAllText(path);

            var route = JsonConvert.DeserializeObject<IEnumerable<T>>(json);

            return route;
        }

    }
}
