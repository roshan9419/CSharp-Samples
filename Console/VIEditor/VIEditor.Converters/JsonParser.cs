using Newtonsoft.Json;
using System.IO;

namespace VIEditor.Converters
{
    public class JsonParser<T>
    {
        /// <summary>
        /// It deserialize loads the json string from specified file and converts that to an object of T type
        /// </summary>
        /// <returns>Object of T type</returns>
        public static T JsonToObject(string fileLocation)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(fileLocation));
        }

        /// <summary>
        /// It serializes the object of T type to json string
        /// </summary>
        /// <returns>The json string of the object</returns>
        public static string ObjectToJson(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
