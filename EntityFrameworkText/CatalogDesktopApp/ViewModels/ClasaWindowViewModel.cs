using DatabaseLayer.DTO;
using System.Collections.Generic;
using System.Windows.Input;

namespace CatalogDesktopApp.ViewModels
{
    public class ClasaWindowViewModel : ViewModelBase
    {
        public ClasaDTO Clasa { get; set; }

        private List<ElevTest> elevi = new List<ElevTest>();
        
        public ClasaWindowViewModel()
        {
            EleviCommand = new RelayCommand(ListElevi);

            Clasa = new ClasaDTO();

            var temp = new List<ElevTest>();

            temp.Add(new ElevTest { Nume = "Vlad", Prenume = "Sava" });
            for (int i = 0; Clasa.Elevi[i] != null; i++)
            {
                temp.Add(new ElevTest { Nume = Clasa.Elevi[i].Nume, Prenume = Clasa.Elevi[i].Prenume });
            }

            Elevi = temp;
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
