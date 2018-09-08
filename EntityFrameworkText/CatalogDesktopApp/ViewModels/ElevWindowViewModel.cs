﻿using CatalogDesktopApp.Services;
using DatabaseLayer.DTO;
using System.Windows.Input;

namespace CatalogDesktopApp.ViewModels
{
    public class ElevWindowViewModel : ViewModelBase
    {
        //private bool note = true;
        //private bool abs = true;
        //private bool obs = true;

        private int _elevID;
        private ElevDTO _elev = new ElevDTO();
        private ElevService _serviceElev;
        private string className;
        private int id;

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

        private MessageBus messageBus;
        
        public ElevWindowViewModel()
        {
            NoteCommand = new RelayCommand(ListNote);

            AbsenteCommand = new RelayCommand(ListAbs);

            ObservatiiCommand = new RelayCommand(ListObs);

            InsertNoteCommand = new RelayCommand(InsertNote);

            InsertAbsenteCommand = new RelayCommand(InsertAbsente);

            InsertObservatiiCommand = new RelayCommand(InsertObservatii);

            _serviceElev = ElevService.Instance;

            messageBus = MessageBus.Instance;
            messageBus.Subscribe<TestMessage>(Getelev);
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

        private void Getelev(TestMessage obj)
        {
            //MessageBox.Show(obj.test.ToString(), "Mesaj primit");
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

        }

        private void InsertNote(object obj)
        {

        }

        private void InsertObservatii(object obj)
        {

        }
    }
}
