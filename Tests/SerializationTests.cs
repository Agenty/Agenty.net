using Agenty.net.Serialization;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class SerializationTests
    {
        [Test]
        public void Can_Serialize_Content_As_String()
        {
            var testModel = new
            {
                UserId = 41,
                Email = "john@domain.com",
                Name = "John Smith",
                RoleId = 4,
                Status = "active"
            };
            var json = JObject.FromObject(testModel, AgentySerializer.Instance);

            Assert.IsNotEmpty(json["user_id"].ToString());
            Assert.IsNotEmpty(json["email"].ToString());
            Assert.IsNotEmpty(json["name"].ToString());
            Assert.IsNotEmpty(json["role_id"].ToString());
            Assert.IsNotEmpty(json["status"].ToString());
        }
    }
}
