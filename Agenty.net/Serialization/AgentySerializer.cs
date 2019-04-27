using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;

namespace Agenty.net.Serialization
{
    public static class AgentySerializer
    {
        private static readonly Lazy<JsonSerializer> LazyJsonSerializer = new Lazy<JsonSerializer>(CreateSerializer);
        public static JsonSerializer Instance => LazyJsonSerializer.Value;

        private static JsonSerializer CreateSerializer()
        {
            var settings = new JsonSerializerSettings { ContractResolver = new AgentyContractResolver() };

            settings.Converters.Add(new UnixDateTimeConverter());
            settings.Converters.Add(new StringEnumConverter { NamingStrategy = new SnakeCaseNamingStrategy(), AllowIntegerValues = false });
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

            return JsonSerializer.Create(settings);
        }
    }

    public static class AgentySerializer<T>
    {
        public static T Deserialize(JsonReader reader)
        {
            return AgentySerializer.Instance.Deserialize<T>(reader);
        }
        public static void Serialize(JsonWriter writer, T value)
        {
            AgentySerializer.Instance.Serialize(writer, value);
        }
    }
}
