using Agenty.net;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
