using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using CatalogDesktopApp.Annotations;
using CatalogDesktopApp.Util;
using CatalogDesktopApp.Views;

namespace CatalogDesktopApp.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private bool _test = true;

        private readonly MessageBus _messageBus;

        private UserControl _currentView;

        public MainWindowViewModel()
        {
            CurrentView = new LoginWindow();

            _messageBus = MessageBus.Instance;

            _messageBus.Subscribe<LoginMessage>(OnLogin);
            _messageBus.Subscribe<LoadClassMessage>(LoadClasa);
        }

        private void LoadClasa(LoadClassMessage obj)
        {
            CurrentView = new ClasaWindow(new ClasaWindowViewModel(obj.Id));
        }

        private void OnLogin(LoginMessage obj)
        {
            if (App.UtilizatorCurent.Tip == ut.elev)
            {
                CurrentView = new ElevWindow(new ElevWindowViewModel(App.UtilizatorCurent.Id));
            }

            if (App.UtilizatorCurent.Tip == ut.profesor)
            {
                CurrentView = new ProfesoriWindow(new ProfesoriWindowViewModel(App.UtilizatorCurent.Id));
            }
        }

        public UserControl CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
