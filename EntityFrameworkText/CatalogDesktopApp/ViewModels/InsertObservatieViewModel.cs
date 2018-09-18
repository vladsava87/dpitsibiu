using CatalogDesktopApp.Services;
using DatabaseLayer.DataModels;
using DatabaseLayer.DTO;
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
        private ProfesorService _profesorService;
        private DateTime _data;
        private ProfesorDTO _profesor;
        private string _explicatie;

        private InsertObservatieMessage _insertObservatieMessage;
        
        public ProfesorDTO Profesor
        {
            get => _profesor;
            set
            {
                _profesor = value;
                OnPropertyChanged("Profesor");
            }
        }

        public string Explicatie
        {
            get => _explicatie;
            set
            {
                _explicatie = value;
                _insertObservatieMessage.Explicatie = _explicatie;
                OnPropertyChanged("Explicatie");
            }
        }

        public DateTime Data
        {
            get => _data;
            set
            {
                _data = value;
                _insertObservatieMessage.Data = _data;
                OnPropertyChanged("Data");
            }
        }

        public InsertObservatieViewModel()
        {
            _messageBus = MessageBus.Instance;
            _profesorService = ProfesorService.Instance;

            var prof = _profesorService.GetProfesorAsync(App.UtilizatorCurent.Id).Result;

            Profesor = new ProfesorDTO();
            _insertObservatieMessage = new InsertObservatieMessage();

            Profesor.Nume = prof.Nume;
            Profesor.Prenume = prof.Prenume;
            _insertObservatieMessage.ProfesorID = prof.Id;

            Data = DateTime.Now;
        }

        public void InsertObservatie()
        {
            _messageBus.Publish(_insertObservatieMessage);
        }
    }
}
