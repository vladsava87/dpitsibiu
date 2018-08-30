using CatalogDesktopApp.Annotations;
using DatabaseLayer.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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

            var temp = new List<ElevTest>();
            temp.Add(new ElevTest { Nume = "Vlad", Prenume = "Sava" });
            temp.Add(new ElevTest { Nume = "Vlad", Prenume = "Sava" });
            temp.Add(new ElevTest { Nume = "Vlad", Prenume = "Sava" });
            temp.Add(new ElevTest { Nume = "Vlad", Prenume = "Sava" });
            temp.Add(new ElevTest { Nume = "Vlad", Prenume = "Sava" });
            temp.Add(new ElevTest { Nume = "Vlad", Prenume = "Sava" });
            temp.Add(new ElevTest { Nume = "Vlad", Prenume = "Sava" });

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
