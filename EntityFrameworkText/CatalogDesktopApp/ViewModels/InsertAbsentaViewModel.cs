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
    public class InsertAbsentaViewModel : ViewModelBase
    {
        private MessageBus _messageBus;
        private ProfesorService _profesorService;
        private List<MaterieDTO> _materii;
        private List<string> _semestre;
        private MaterieDTO _selectedMaterie;
        private string _semestru;
        private DateTime _data;
        private ProfesorDTO _profesor;

        private InsertAbsentaMessage _insertAbsentaMessage;

        public DateTime Data
        {
            get => _data;
            set
            {
                _data = value;
                _insertAbsentaMessage.Data = _data;
                OnPropertyChanged("Data");
            }
        }

        public List<MaterieDTO> Materii
        {
            get => _materii;
            set
            {
                _materii = value;
                OnPropertyChanged("Materii");
            }
        }

        public List<string> Semestre
        {
            get => _semestre;
            set
            {
                _semestre = value;
                OnPropertyChanged("Semestre");
            }
        }

        public string Semestru
        {
            get => _semestru;
            set
            {
                _semestru = value;
                if(_semestru == "Semestrul I")
                {
                    _insertAbsentaMessage.Semestrul = 0;
                }
                if (_semestru == "Semestrul II")
                {
                    _insertAbsentaMessage.Semestrul = 1;
                }
                OnPropertyChanged("Semestru");
            }
        }

        public MaterieDTO SelectedMaterie
        {
            get => _selectedMaterie;
            set
            {
                _selectedMaterie = value;

                _insertAbsentaMessage.MaterieID = _selectedMaterie.Id;
                OnPropertyChanged("SelectedMaterie");
            }
        }

        public ProfesorDTO Profesor
        {
            get => _profesor;
            set
            {
                _profesor = value;
                OnPropertyChanged("Profesor");
            }
        }

        public InsertAbsentaViewModel()
        {
            _messageBus = MessageBus.Instance;
            _profesorService = ProfesorService.Instance;

            Materii = new List<MaterieDTO>();
            _insertAbsentaMessage = new InsertAbsentaMessage();

            var prof = _profesorService.GetProfesorAsync(App.UtilizatorCurent.Id).Result;

            if(prof != null)
            {
                Materii = prof.Materie;
            }

            Profesor = new ProfesorDTO();

            Profesor.Nume = prof.Nume;
            Profesor.Prenume = prof.Prenume;

            Semestre = new List<string>();

            Semestre.Add("Semestrul I");
            Semestre.Add("Semestrul II");

            Data = DateTime.Now;
        }

        public void InsertAbsenta()
        {
            _messageBus.Publish(_insertAbsentaMessage);
        }

    }
}
