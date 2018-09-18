using CatalogDesktopApp.Services;
using DatabaseLayer.DataModels;
using DatabaseLayer.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace CatalogDesktopApp.ViewModels
{
    public class ElevWindowViewModel : ViewModelBase
    {
        private int _elevID;
        private ElevDTO _elev = new ElevDTO();
        private ElevService _serviceElev;
        private string className;
        private NotaService serviciuNota;
        private AbsentaService serviciuAbsenta;
        private ObservatieService serviciuObservatie;
        private ClasaService _serviciuClasa;
        private MessageBus messageBus;
        private List<NotaDTO> _nota = new List<NotaDTO>();
        private List<AbsentaDTO> _absenta = new List<AbsentaDTO>();
        private List<ObservatieDTO> _observatie = new List<ObservatieDTO>();
        private int _diriginteElevId;

        public ICommand NoteCommand { get; set; }
        public ICommand AbsenteCommand { get; set; }
        public ICommand ObservatiiCommand { get; set; }
        public ICommand InsertNoteCommand { get; set; }
        public ICommand InsertAbsenteCommand { get; set; }
        public ICommand InsertObservatiiCommand { get; set; }

        public ElevDTO Elev
        {
            get => _elev;
            set
            {
                _elev = value;
                OnPropertyChanged("Elev");
            }
        }

        public List<NotaDTO> Note
        {
            get => _nota;
            set
            {
                _nota = value;
                OnPropertyChanged("Note");
            }
        }

        public List<AbsentaDTO> Absente
        {
            get => _absenta;
            set
            {
                _absenta = value;
                OnPropertyChanged("Absente");
            }
        }

        public List<ObservatieDTO> Observatii
        {
            get => _observatie;
            set
            {
                _observatie = value;
                OnPropertyChanged("Observatii");
            }
        }

        private bool noteVisible = false;

        public bool NoteVisible
        {
            get
            {
                return noteVisible;
            }

            set
            {
                noteVisible = value;
                OnPropertyChanged("NoteVisible");
            }
        }

        private bool absenteVisible = false;

        public bool AbsenteVisible
        {
            get
            {
                return absenteVisible;
            }

            set
            {
                absenteVisible = value;
                OnPropertyChanged("AbsenteVisible");
            }
        }

        private bool observatiiVisible = false;

        public bool ObservatiiVisible
        {
            get
            {
                return observatiiVisible;
            }

            set
            {
                observatiiVisible = value;
                OnPropertyChanged("ObservatiiVisible");
            }
        }

        public ElevWindowViewModel()
        {
            NoteCommand = new RelayCommand(ListNote, CanListNote);

            AbsenteCommand = new RelayCommand(ListAbs, CanListAbs);

            ObservatiiCommand = new RelayCommand(ListObs, CanListObs);

            InsertNoteCommand = new RelayCommand(InsertNote, CanInsertNote);

            InsertAbsenteCommand = new RelayCommand(InsertAbsente, CanInsertAbsente);

            InsertObservatiiCommand = new RelayCommand(InsertObservatii, CanInsertObservatii);

            _serviceElev = ElevService.Instance;

            messageBus = MessageBus.Instance;
            _serviciuClasa = ClasaService.Instance;

            messageBus.Subscribe<InsertNotaMessage>(SetNotaInserata);
            serviciuNota = NotaService.Instance;

            messageBus.Subscribe<InsertAbsentaMessage>(SetAbsentaInserata);
            serviciuAbsenta = AbsentaService.Instance;

            messageBus.Subscribe<InsertObservatieMessage>(SetObservatieInserata);
            serviciuObservatie = ObservatieService.Instance;
        }

        private bool CanListObs(object arg)
        {
            return !ObservatiiVisible;
        }

        private bool CanListAbs(object arg)
        {
            return !AbsenteVisible;
        }

        private bool CanListNote(object arg)
        {
            return !NoteVisible;
        }

        private bool CanInsertObservatii(object arg)
        {
            return (App.UtilizatorCurent.Tip == Util.ut.profesor);
        }

        private bool CanInsertAbsente(object arg)
        {
            return (App.UtilizatorCurent.Tip == Util.ut.profesor);
        }

        private bool CanInsertNote(object arg)
        {
            return (App.UtilizatorCurent.Tip == Util.ut.profesor);
        }

        private void SetNotaInserata(InsertNotaMessage obj)
        {
            NotaDTO notaInserata = new NotaDTO();

            notaInserata.Data = obj.Data;
            notaInserata.MaterieID = obj.MaterieID;
            notaInserata.Teza = obj.Teza;
            notaInserata.Nota = obj.Nota;
            notaInserata.Semestrul = (sem)obj.Semestrul;
            notaInserata.ElevID = _elevID;

            serviciuNota.PostNotaAsync(notaInserata);
        }

        private void SetAbsentaInserata(InsertAbsentaMessage obj)
        {
            AbsentaDTO absentaInserata = new AbsentaDTO();

            absentaInserata.Data = obj.Data;
            absentaInserata.MaterieID = obj.MaterieID;
            absentaInserata.Motivata = obj.Motivata;
            absentaInserata.ProfesorID = obj.ProfesorID;
            absentaInserata.Semestrul = (sem)obj.Semestrul;
            absentaInserata.ElevID = _elevID;

            serviciuAbsenta.PostAbsentaAsync(absentaInserata);
        }

        private void SetObservatieInserata(InsertObservatieMessage obj)
        {
            ObservatieDTO observatieInserata = new ObservatieDTO();

            observatieInserata.Data = obj.Data;
            observatieInserata.ProfesorID = obj.ProfesorID;
            observatieInserata.Text = obj.Explicatie;

            serviciuObservatie.PostObservatieAsync(observatieInserata);
        }

        public ElevWindowViewModel(int id, int diriginteElevId = 0) : this()
        {
            InitViewModel(id);
            _diriginteElevId = diriginteElevId;
        }

        public void InitViewModel(int id)
        {
            _elevID = id;

            Elev = _serviceElev.GetElevAsync(_elevID).Result;

            var clasaElevului = _serviciuClasa.GetClasaAsync(_elevID).Result;
            ClassName = clasaElevului.Numar + " " + clasaElevului.Serie + " " + clasaElevului.Profil.Nume;
        }

        public string ClassName
        {
            get { return className; }
            set
            {
                className = value;
                OnPropertyChanged(ClassName);
            }
        }

        private void ListObs(object obj)
        {
            Observatii = serviciuObservatie.GetListaObservatieAsync(_elevID).Result;
            ObservatiiVisible = true;
            NoteVisible = !ObservatiiVisible;
            AbsenteVisible = !ObservatiiVisible;
        }

        private void ListAbs(object obj)
        {
            Absente = serviciuAbsenta.GetListaAbsentaAsync(_elevID).Result;
            AbsenteVisible = true;
            ObservatiiVisible = !AbsenteVisible;
            NoteVisible = !AbsenteVisible;
        }

        private void ListNote(object obj)
        {
            Note = serviciuNota.GetListaNotaAsync(_elevID).Result;
            NoteVisible = true;
            ObservatiiVisible = !NoteVisible;
            AbsenteVisible = !NoteVisible;
        }

        private void InsertAbsente(object obj)
        {
            var message = new ShowAbsenteWindow();
            message.MaterieID = 1;
            //message.Materia = "Istorie";
            message.ProfesorID = App.UtilizatorCurent.Id;
            //message.Profesor = "Ion";
            messageBus.Publish(message);
        }

        private void InsertNote(object obj)
        {
            var message = new ShowNoteWindow();
            message.MaterieID = 1;
            //message.Materia = "Istorie";
            messageBus.Publish(message);
        }

        private void InsertObservatii(object obj)
        {
            var message = new ShowObservatiiWindow();
            message.ProfesorID = App.UtilizatorCurent.Id;
            //message.Profesor = "Ion";
            messageBus.Publish(message);
        }

        public void MotivareAbsenta()
        {
            if (_diriginteElevId == App.UtilizatorCurent.Id)
            {

            }
        }
    }
}
