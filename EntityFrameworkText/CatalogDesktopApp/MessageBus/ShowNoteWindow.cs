using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogDesktopApp
{
    public class ShowNoteWindow : IMessage
    {
        public int MaterieID { get; set; }

        public string Materia { get; set; }
    }
}
