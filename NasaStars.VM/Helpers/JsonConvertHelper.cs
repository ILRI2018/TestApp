using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace NasaStars.VM.Helpers
{
    public static class JsonSettings
    {
        public static JsonSerializerSettings Default { get; set; }

        static JsonSettings() => Default = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver()};
    }

    public static class JsonConvertHelper
    {
        public static string GetJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static byte[] GetJsonBytes(object obj)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
        }

        public static T GetObject<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str, JsonSettings.Default);
        }

        public static T GetObject<T>(byte[] bytes)
        {
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(bytes), JsonSettings.Default);
        }
    }
}
