using CatalogDesktopApp.Services;
using DatabaseLayer.DTO;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace CatalogDesktopApp.ViewModels
{
    public class ClasaWindowViewModel : ViewModelBase
    {
        private int _classId;

        private ClasaService _clasaService;
        private ClasaDTO clasa;// = new ClasaDTO();
        private ElevDTO curentelev;// = new ElevDTO();
        private List<ElevDTO> elevi;// = new List<ElevDTO>();
        private ElevWindowViewModel viewModelElev;

        public ICommand EleviCommand { get; set; }

        public ClasaDTO Clasa
        {
            get => clasa;
            set
            {
                clasa = value;
                OnPropertyChanged("Clasa");
                Elevi = clasa.Elevi;
            }
        }

        public List<ElevDTO> Elevi
        {
            get => elevi;

            set
            {
                elevi = value;
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

        public ElevWindowViewModel ViewModelElev
        {
            get => viewModelElev;
            set
            {
                viewModelElev = value;
                OnPropertyChanged("ViewModelElev");
            }
        }

        private void UpdateElevInfo(int id)
        {
            ViewModelElev = new ElevWindowViewModel();

            ViewModelElev.InitViewModel(id);
        }

        public ClasaWindowViewModel()
        {
            EleviCommand = new RelayCommand(ListElevi);

            _clasaService = ClasaService.Instance;
        }

        public async void InitViewModel(int id)
        {
            _classId = id;

            Clasa = await _clasaService.GetClasa(_classId);
        }

        public void ListElevi(object obj)
        {

        }

    }
}
