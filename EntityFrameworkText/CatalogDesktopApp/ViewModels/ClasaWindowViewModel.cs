using CatalogDesktopApp.Services;
using DatabaseLayer.DTO;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace CatalogDesktopApp.ViewModels
{
    public class ClasaWindowViewModel : ViewModelBase
    {
        private int _classId;

        private ClasaService _clasaService;

        public ClasaDTO Clasa
        {
            get => clasa;
            set
            {
                clasa = value;
                OnPropertyChanged("Clasa");
            }
        }

        private ClasaDTO clasa = new ClasaDTO(); 

        private List<ElevTest> elevi = new List<ElevTest>();

        public async void InitViewModel(int id)
        {
            _classId = id;

            Clasa = await _clasaService.GetClasa(_classId);
        }
        
        public ClasaWindowViewModel()
        {
            EleviCommand = new RelayCommand(ListElevi);

            _clasaService = ClasaService.Instance;
        }

        public List<ElevTest> Elevi
        {
            get => elevi;

            set
            {
                elevi = value;
                OnPropertyChanged("Elevi");
            }
        }

        public void ListElevi(object obj)
        {

        }

        public ICommand EleviCommand { get; set; }
    }

    public class ElevTest
    {
        public string Nume { get; set; }

        public string Prenume { get; set; }
    }
}
