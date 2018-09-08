using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogDesktopApp
{
    public class InsertNotaMessage : IMessage
    {
        public int MaterieID { get; set; }

        public bool Teza { get; set; }

        public double Nota { get; set; }

        public DateTime Data { get; set; }

        public int Semestrul { get; set; }
    }
}
