using CatalogDesktopApp.Annotations;
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
        private bool note = true;
        private bool abs = true;
        private bool obs = true;

        public ElevWindowViewModel()
        {
            NoteCommand = new RelayCommand(ListNote, CanListNote);

            AbsenteCommand = new RelayCommand(ListAbs, CanListAbs);

            ObservatiiCommand = new RelayCommand(ListObs, CanListObs);
        }

        private bool CanListObs(object arg)
        {
            return obs;
        }

        private void ListObs(object obj)
        {
            obs = false;
        }

        private bool CanListAbs(object arg)
        {
            return abs;
        }

        private void ListAbs(object obj)
        {
            abs = false;
        }

        private bool CanListNote(object arg)
        {
            return note;
        }

        private void ListNote(object obj)
        {
            note = false;
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
