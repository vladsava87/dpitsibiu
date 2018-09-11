using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogDesktopApp.ViewModels
{
    public class InsertNoteViewModel : ViewModelBase
    {
        private MessageBus _messageBus;
        private string materieNume;
        public int Nota { get; set; }
       //public bool Teza { get; set; }

        public int MaterieID { get; set; }

        public string Materie
        {
            get => materieNume;
            set
            {
                materieNume = value;
                OnPropertyChanged("Materie");
            }
        }

        public InsertNoteViewModel()
        {
            _messageBus = MessageBus.Instance;
        }

        public void InsertNota()
        {
            var notaInserata = new InsertNotaMessage();

            _messageBus.Publish(notaInserata);
        }
    }
}
