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
    public class ClasaWindowViewModel : INotifyPropertyChanged
    {
        public ClasaDTO Clasa { get; set; }
        
        public ClasaWindowViewModel()
        {
            EleviCommand = new RelayCommand(ListElevi);
        }

        public void ListElevi(object obj)
        {

        }

        public ICommand EleviCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
