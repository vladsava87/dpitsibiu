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
    public class ProfesoriWindowViewModel : ViewModelBase
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
    }
}