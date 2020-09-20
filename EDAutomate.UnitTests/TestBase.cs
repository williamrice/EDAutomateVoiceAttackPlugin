using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDAutomate.UnitTests
{
    public class TestBase
    {
        public Mock<Proxy> Proxy { get; set; }

        public TestBase()
        {
            Proxy = new Mock<Proxy>();
        }
    }
}
