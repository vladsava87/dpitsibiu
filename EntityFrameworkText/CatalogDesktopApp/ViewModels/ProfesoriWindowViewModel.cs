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
    public class ProfesoriWindowViewModel : INotifyPropertyChanged
    {
        public ProfesorDTO Profesor
        {
            get; set;
        }

        public ProfesoriWindowViewModel()
        {

           Profesor = new ProfesorDTO();
           Profesor.Nume = "Mihai";
           Profesor.Prenume = "Popa";
           Profesor.Email = "MPopa@gmail.ro";
     


        }

        public string NumePrenume
        {
            get { return Profesor.Nume + " " + Profesor.Prenume; }

        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}