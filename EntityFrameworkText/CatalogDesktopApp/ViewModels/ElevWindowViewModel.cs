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
    public class ElevWindowViewModel : INotifyPropertyChanged
    {
        //private bool note = true;
        //private bool abs = true;
        //private bool obs = true;
        public ElevDTO Elev
        {
            get; set;
        }

        public ElevWindowViewModel()
        {
            NoteCommand = new RelayCommand(ListNote);

            AbsenteCommand = new RelayCommand(ListAbs);

            ObservatiiCommand = new RelayCommand(ListObs);

            Elev = new ElevDTO();
            Elev.Nume = "Mihai";
            Elev.Prenume = "Popescu";
            Elev.Email = "MP@gmail.ro";
            Elev.Telefon = "097532678";
            Elev.Numar_Matricol = 1234;

            ClassName = "12A";


        }

        public string NumePrenume
        {
            get { return Elev.Nume + " " + Elev.Prenume; }

        }

        private string className;

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

        }

        public ICommand NoteCommand { get; set; }
        public ICommand AbsenteCommand { get; set; }
        public ICommand ObservatiiCommand { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
