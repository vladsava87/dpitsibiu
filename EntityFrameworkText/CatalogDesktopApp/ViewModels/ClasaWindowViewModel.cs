using CatalogDesktopApp.Services;
using DatabaseLayer.DTO;
using System.Collections.Generic;
using System.Windows.Controls;
using CatalogDesktopApp.Views;
using System.Windows.Input;
using System;

namespace CatalogDesktopApp.ViewModels
{
    public class ClasaWindowViewModel : ViewModelBase
    {
        private int _classId;
        private ClasaService _clasaService;
        private List<ElevDTO> _elevi;
        private ClasaDTO clasa;
        private ElevDTO curentelev;
        private UserControl viewModelElev;
        private int _diriginteId;
        private int _materieId;

        public ICommand BackMessage { get; set; }

        private MessageBus _messageBus;
        public ClasaDTO Clasa
        {
            get => clasa;
            set
            {
                clasa = value;
                _diriginteId = clasa.DiriginteID;
                OnPropertyChanged("Clasa");
                if (clasa.Elevi != null)
                {
                    Elevi = clasa.Elevi;
                }
            }
        }

        public List<ElevDTO> Elevi
        {
            get => _elevi;
            set
            {
                _elevi = value;
                OnPropertyChanged("Elevi");
            }
        }

        public ElevDTO CurrentElev
        {
            get => curentelev;
            set
            {
                curentelev = value;
                OnPropertyChanged("CurentElev");
                UpdateElevInfo(curentelev.Id);
            }
        }

        public UserControl CurrentViewElev
        {
            get => viewModelElev;
            set
            {
                viewModelElev = value;
                OnPropertyChanged("CurrentViewElev");
            }
        }

        private void UpdateElevInfo(int id)
        {
            CurrentViewElev = new ElevWindow(new ElevWindowViewModel(id, _diriginteId));
        }

        public ClasaWindowViewModel()
        {
            _clasaService = ClasaService.Instance;
            _messageBus = MessageBus.Instance;

            BackMessage = new RelayCommand(BackListFunction);

        }

        private void BackListFunction(object obj)
        {
            _messageBus.Publish(new LoadingMessage());
        }

        public ClasaWindowViewModel(int v) : this()
        {
            Clasa = _clasaService.GetClasaAsync(v).Result;
        }
    }
}
