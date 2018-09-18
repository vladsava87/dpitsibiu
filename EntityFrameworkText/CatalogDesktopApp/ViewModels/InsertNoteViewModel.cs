using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogDesktopApp.Services;
using DatabaseLayer.DTO;

namespace CatalogDesktopApp.ViewModels
{
    public class InsertNoteViewModel : ViewModelBase
    {
        private MessageBus _messageBus;
        private ProfesorService _profesorService;
        private List<MaterieDTO> _materii;
        private List<string> _semestre;
        private MaterieDTO _selectedMaterie;
        private string _semestru;
        private double _nota;
        private DateTime _data;
        private bool _teza { get; set; }

        private InsertNotaMessage _insertNotaMessage;


        public bool Teza
        {
            get => _teza;
            set
            {
                _teza = value;
                _insertNotaMessage.Teza = _teza;
                OnPropertyChanged("Teza");
            }
        }

        public double Nota
        {
            get => _nota;
            set
            {
                _nota = value;
                _insertNotaMessage.Nota = _nota;
                OnPropertyChanged("Nota");
            }
        }

        public DateTime Data
        {
            get => _data;
            set
            {
                _data = value;
                _insertNotaMessage.Data = _data;
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
                if (_semestru == "Semestrul I")
                {
                    _insertNotaMessage.Semestrul = 0;
                }
                if (_semestru == "Semestrul II")
                {
                    _insertNotaMessage.Semestrul = 1;
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

                _insertNotaMessage.MaterieID = _selectedMaterie.Id;
                OnPropertyChanged("SelectedMaterie");
            }
        }

        public InsertNoteViewModel()
        {
            _messageBus = MessageBus.Instance;
            _profesorService = ProfesorService.Instance;

            Materii = new List<MaterieDTO>();
            _insertNotaMessage = new InsertNotaMessage();

            var prof = _profesorService.GetProfesorAsync(App.UtilizatorCurent.Id).Result;

            if (prof != null)
            {
                Materii = prof.Materie;
            }

            Semestre = new List<string>();

            Semestre.Add("Semestrul I");
            Semestre.Add("Semestrul II");

            Data = DateTime.Now;
        }

        public void InsertNota()
        {
            _messageBus.Publish(_insertNotaMessage);
        }
    }
}
