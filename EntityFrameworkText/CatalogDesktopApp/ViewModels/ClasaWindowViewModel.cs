using CatalogDesktopApp.Services;
using DatabaseLayer.DTO;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using CatalogDesktopApp.Views;

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

        private MessageBus _messageBus;

        public ICommand EleviCommand { get; set; }

        public ClasaDTO Clasa
        {
            get => clasa;
            set
            {
                clasa = value;
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
            CurrentViewElev = new ElevWindow(new ElevWindowViewModel(id));
        }

        public ClasaWindowViewModel()
        {
            EleviCommand = new RelayCommand(ListElevi);

            _clasaService = ClasaService.Instance;
            _messageBus = MessageBus.Instance;
        }

        public ClasaWindowViewModel(int v) : this()
        {
            Clasa = _clasaService.GetClasaAsync(v).Result;
        }

        public void ListElevi(object obj)
        {

        }
    }
}
