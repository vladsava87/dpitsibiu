using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogDesktopApp.ViewModels
{
    public class InsertObservatieViewModel : ViewModelBase
    {
        private MessageBus _messageBus;
        private string profesorNume;
        public string Explicatie { get; set; }
        public int  ProfesorID { get; set; }

        public string Profesor
        {
            get => profesorNume;
            set
            {
                profesorNume = value;
                OnPropertyChanged("Profesor");
            }
        }

        public InsertObservatieViewModel()
        {
            _messageBus = MessageBus.Instance;
        }

        public void InsertObservatie()
        {
            var observatieInserata = new InsertObservatieMessage();

            _messageBus.Publish(observatieInserata);
        }
    }
}
