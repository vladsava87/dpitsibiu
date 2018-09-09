using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogDesktopApp
{
    public class InsertObservatieMessage : IMessage
    {
        public int ProfesorID { get; set; }

        public DateTime Data { get; set; }

        public string Explicatie { get; set; }
    }
}
