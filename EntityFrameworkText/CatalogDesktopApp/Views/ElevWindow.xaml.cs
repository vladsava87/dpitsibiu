using System.Windows.Controls;
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
    }
}
