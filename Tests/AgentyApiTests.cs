using Agenty.net;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class AgentyApiTests
    {
        [Test]
        public void Agenty_Api_Created_Successfully()
        {
            Assert.DoesNotThrow(() => new AgentyApi("Test Api Key"));
        }

        [Test]
        public void AgentyApi_non_default_client_is_configured()
        {
            var client = new HttpClient();

            using (var api = new AgentyApi("api_key", client))
            {
                Assert.IsTrue(api.HttpClient.BaseAddress.OriginalString == "https://api.agenty.com/v1/", "Base Address is wrong");
                Assert.IsTrue(api.HttpClient.DefaultRequestHeaders.Accept.Count() == 1, "Header count is wrong");
            }
        }

        [Test]
        public async Task AgentyApi_is_disposed_successfully()
        {
            var api = new AgentyApi("api_key");
            api.Dispose();
        }

        [Test]
        public async Task AgentyApi_non_default_client_controls_its_lifecycle()
        {
            var client = new HttpClient{ BaseAddress = new Uri("https://test.proxy.local/") };

            using (var api = new AgentyApi("api_key", client))
            {
                Assert.IsTrue(api.HttpClient.BaseAddress.OriginalString == "https://test.proxy.local/");
            }

            try
            {
                await client.GetAsync("test");
            }
            catch (ObjectDisposedException)
            {
                Assert.Fail("Should not have been disposed");
            }
            catch (HttpRequestException)
            {
                // don't do anything
            }
        }
    }
}
