using Agenty.net;
using Agenty.net.Models;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    class AgentyRequestTests
    {
        private AgentyRequest agentyRequest;
        [SetUp]
        public void Initialize()
        {
            agentyRequest = new AgentyRequest("test api key", new HttpClient());
        }

        [Test]
        public async Task AgentyRequest_Should_Post_Successfully()
        {
            var response = await agentyRequest.PostAsync<AgentyRequestBase, object>("test", new AgentyRequestBase());

            Assert.NotNull(response);
        }
    }
}
