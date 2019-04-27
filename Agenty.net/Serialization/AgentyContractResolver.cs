using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Reflection;

namespace Agenty.net.Serialization
{
    class AgentyContractResolver : DefaultContractResolver
    {
        public AgentyContractResolver()
        {
            NamingStrategy = new SnakeCaseNamingStrategy(false, false);
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var jsonProperty =  base.CreateProperty(member, memberSerialization);
            var propertyType = jsonProperty.PropertyType;

            // don't serialize empty list or dictionaries unless overriden
            if (jsonProperty.ShouldSerialize == null)
            {
                if (propertyType.GetTypeInfo().IsGenericType && propertyType.GenericTypeArguments.Length == 1)
                {
                    var t = propertyType.GenericTypeArguments[0];

                    if (typeof(IList<>).MakeGenericType(t).GetTypeInfo().IsAssignableFrom(propertyType.GetTypeInfo()))
                    {
                        var prop = jsonProperty.DeclaringType.GetTypeInfo().GetDeclaredProperty(member.Name);
                        jsonProperty.ShouldSerialize = instance =>
                        {
                            return (prop.GetValue(instance) as System.Collections.ICollection)?.Count > 0;
                        };
                    }
                }

                if (typeof(IDictionary<string, string>).GetTypeInfo().IsAssignableFrom(propertyType.GetTypeInfo()))
                {
                    var prop = jsonProperty.DeclaringType.GetTypeInfo().GetDeclaredProperty(member.Name);

                    jsonProperty.ShouldSerialize = instance =>
                    {
                        return (prop.GetValue(instance) as IDictionary<string, string>)?.Count > 0;
                    };
                }

                if (typeof(IDictionary<string, object>).GetTypeInfo().IsAssignableFrom(propertyType.GetTypeInfo()))
                {
                    var prop = jsonProperty.DeclaringType.GetTypeInfo().GetDeclaredProperty(member.Name);

                    jsonProperty.ShouldSerialize = instance =>
                    {
                        return (prop.GetValue(instance) as IDictionary<string, object>)?.Count > 0;
                    };
                }
            }

            return jsonProperty;
        }
    }
}
