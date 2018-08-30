using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogDesktopApp
{
    public class TestMessage : IMessage
    {
        public TestMessage()
        {
        }

        public int test { get; set; }

        public string Str { get; set; }
    }
}
