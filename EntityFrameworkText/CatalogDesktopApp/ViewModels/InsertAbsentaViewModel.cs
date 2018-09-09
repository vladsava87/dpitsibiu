using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogDesktopApp.ViewModels
{
    public class InsertAbsentaViewModel : ViewModelBase
    {
        private MessageBus _messageBus;

        private string profesorNume;
        private string materieNume;

        public int ProfesorID { get; set; }
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

        public string Profesor
        {
            get => profesorNume;
            set
            {
                profesorNume = value;
                OnPropertyChanged("Profesor");
            }
        }

        public InsertAbsentaViewModel()
        {
            _messageBus = MessageBus.Instance;
        }

        public void InsertAbsenta()
        {
            var absentaInserata = new InsertAbsentaMessage();

            _messageBus.Publish(absentaInserata);
        }
    }
}
