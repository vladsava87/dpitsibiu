﻿using CatalogDesktopApp.Services;
using DatabaseLayer.DTO;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using CatalogDesktopApp.Views;

namespace CatalogDesktopApp.ViewModels
{
    public class ProfesoriWindowViewModel : ViewModelBase
    {
        private int _profesorId;
        private ProfesorService _profesorService;
        private List<ClasaDTO> _clase;
        private ProfesorDTO profesor;
        private ClasaDTO curentclasa;
        private UserControl viewModelClasa;

        private MessageBus _messageBus;

        public ICommand ClasaCommand { get; set; }

        public ProfesorDTO Profesor
        {
            get => profesor;
            set
            {
                profesor = value;
                OnPropertyChanged("Profesor");
                if (profesor.Clasa != null)
                {
                    Clase = profesor.Clasa;
                }
            }
        }

        public List<ClasaDTO> Clase
        {
            get => _clase;
            set
            {
                _clase = value;
                OnPropertyChanged("Clasa");
            }
        }

        public ClasaDTO CurrentClasa
        {
            get => curentclasa;
            set
            {
                curentclasa = value;
                OnPropertyChanged("CurentClasa");
                UpdateClasaInfo(curentclasa.Id);
            }
        }

        public UserControl CurrentViewClasa
        {
            get => viewModelClasa;
            set
            {
                viewModelClasa = value;
                OnPropertyChanged("CurrentViewClasa");
            }
        }

        private void UpdateClasaInfo(int id)
        {
            CurrentViewClasa = new ClasaWindow(new ClasaWindowViewModel(id));
        }

        public ProfesoriWindowViewModel()
        {
            ClasaCommand = new RelayCommand(ListClasa);

            _profesorService = ProfesorService.Instance;
            _messageBus = MessageBus.Instance;
        }

        public ProfesoriWindowViewModel(int v) : this()
        {
            Profesor = _profesorService.GetProfesorAsync(v).Result;
        }

        public void ListClasa(object obj)
        {

        }
    }
}
