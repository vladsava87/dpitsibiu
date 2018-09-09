using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogDesktopApp
{
    public class ShowObservatiiWindow : IMessage
    {
        public int ProfesorID { get; set; }

        public string Profesor { get; set; }
    }
}
