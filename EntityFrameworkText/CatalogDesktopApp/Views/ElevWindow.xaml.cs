using System.Windows.Controls;
using System.Windows.Input;
using CatalogDesktopApp.ViewModels;

namespace CatalogDesktopApp.Views
{
    /// <summary>
    /// Interaction logic for ElevWindow.xaml
    /// </summary>
    public partial class ElevWindow : UserControl
    {
        public ElevWindow()
        {
            InitializeComponent();
        }

        public ElevWindow(ElevWindowViewModel elevWindowViewModel)
        {
            InitializeComponent();
            DataContext = elevWindowViewModel;
        }

        private void DataGrid_Row_DoubleClick_Event(object sender, MouseButtonEventArgs e)
        {
            (DataContext as ElevWindowViewModel).MotivareAbsenta();
        }
    }
}
