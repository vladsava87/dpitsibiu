using System.Windows;
using System.Windows.Controls;
using CatalogDesktopApp.ViewModels;

namespace CatalogDesktopApp.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : UserControl
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            (DataContext as LoginWindowViewModel).PasswordTextBox = PasswordBox.Password;
        }
    }
}
