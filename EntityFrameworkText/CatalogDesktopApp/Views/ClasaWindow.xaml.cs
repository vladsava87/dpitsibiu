using System.Windows;
using System.Windows.Controls;
using CatalogDesktopApp.ViewModels;

namespace CatalogDesktopApp.Views
{
    /// <summary>
    /// Interaction logic for ClasaWindow.xaml
    /// </summary>
    public partial class ClasaWindow : UserControl
    {
        public ClasaWindow(ClasaWindowViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
