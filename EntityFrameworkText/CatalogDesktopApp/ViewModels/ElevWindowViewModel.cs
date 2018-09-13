﻿using CatalogDesktopApp.Services;
using DatabaseLayer.DataModels;
using DatabaseLayer.DTO;
using System;
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
        private MessageBus messageBus;

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

        public ElevWindowViewModel()
        {
            NoteCommand = new RelayCommand(ListNote);
            
            AbsenteCommand = new RelayCommand(ListAbs);

            ObservatiiCommand = new RelayCommand(ListObs);

            InsertNoteCommand = new RelayCommand(InsertNote, CanInsertNota);
            
            InsertAbsenteCommand = new RelayCommand(InsertAbsente, CanInsertAbsenta);

            InsertObservatiiCommand = new RelayCommand(InsertObservatii, CanInsertObservatie);

            _serviceElev = ElevService.Instance;

            messageBus = MessageBus.Instance;

            messageBus.Subscribe<InsertNotaMessage>(SetNotaInserata);
            serviciuNota = NotaService.Instance;

            messageBus.Subscribe<InsertAbsentaMessage>(SetAbsentaInserata);
            serviciuAbsenta = AbsentaService.Instance;

            messageBus.Subscribe<InsertObservatieMessage>(SetObservatieInserata);
            serviciuObservatie = ObservatieService.Instance;
        }

        private bool CanInsertObservatie(object arg)
        {
            if (App.UtilizatorCurent.Tip == Util.ut.profesor)
                return true;
            else
                return false;
        }

        private bool CanInsertAbsenta(object arg)
        {
            if (App.UtilizatorCurent.Tip == Util.ut.profesor)
                return true;
            else
                return false;
        }

        private bool CanInsertNota(object arg)
        {
            if (App.UtilizatorCurent.Tip == Util.ut.profesor)
                return true;
            else
                return false;
        }

        private void SetNotaInserata(InsertNotaMessage obj)
        {
            NotaDTO notaInserata = new NotaDTO();

            notaInserata.Data = obj.Data;
            notaInserata.MaterieID = obj.MaterieID;
            notaInserata.Teza = obj.Teza;
            notaInserata.Semestrul = (sem)obj.Semestrul;

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

        public ElevWindowViewModel(int id) : this()
        {
            InitViewModel(id);
        }

        public void InitViewModel(int id)
        {
            _elevID = id;

            Elev = _serviceElev.GetElevAsync(_elevID).Result;
        }
        
        public string NumePrenume
        {
            get { return Elev.Nume + " " + Elev.Prenume; }
            //get => "tets";
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

        }

        private void ListAbs(object obj)
        {

        }

        private void ListNote(object obj)
        {
            //messageBus.Publish<TestMessage>(new TestMessage(3));
        }

        private void InsertAbsente(object obj)
        {
            
            
                var message = new ShowAbsenteWindow();
                message.MaterieID = 1;
                message.Materia = "Istorie";
                message.ProfesorID = 1;
                message.Profesor = "Ion";
                messageBus.Publish(message);
            
        }

        private void InsertNote(object obj)
        {
           
                var message = new ShowNoteWindow();
                message.MaterieID = 1;
                message.Materia = "Istorie";
                messageBus.Publish(message);
            
        }

        private void InsertObservatii(object obj)
        {
            
                var message = new ShowObservatiiWindow();
                message.ProfesorID = 1;
                message.Profesor = "Ion";
                messageBus.Publish(message);
            
        }
    }
}
