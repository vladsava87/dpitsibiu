using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using CatalogDesktopApp.Annotations;
using System.Windows.Input;
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
            MyClickCommand = new RelayCommand(ClickCommand, CanClickCommand);

            My2ClickCommand = new RelayCommand(OtherClickCommand);

            CurrentView = new LoginWindow();

            _messageBus = MessageBus.Instance;

            _messageBus.Subscribe<TestMessage>(OnLogin);
        }

        private void OnLogin(TestMessage obj)
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

        private void OtherClickCommand(object obj)
        {
            _test = true;

            MyLabel = "Text For Label";
        }

        private bool CanClickCommand(object arg)
        {
            return _test;
        }

        private void ClickCommand(object obj)
        {

            _test = false;
            MyLabel = MyLabel + " false";
        }

        public ICommand MyClickCommand { get; set; }

        private string _MyLabel;

        public string MyLabel
        {
            get
            {
                return _MyLabel;
            }
            set
            {
                _MyLabel = value;
                OnPropertyChanged("MyLabel");
            }
        }

        public ICommand My2ClickCommand { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
