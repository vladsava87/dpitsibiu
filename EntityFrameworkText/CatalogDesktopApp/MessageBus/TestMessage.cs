using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogDesktopApp
{
    public class TestMessage : IMessage
    {
        public TestMessage(int t) { test = t; }

        public int test { get; set; }
    }
}
