using CatalogDesktopApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CatalogDesktopApp.Views
{
    /// <summary>
    /// Interaction logic for InsertObservatie.xaml
    /// </summary>
    public partial class InsertObservatie : Window
    {
        public InsertObservatie()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ((InsertObservatieViewModel)DataContext).InsertObservatie();
            this.Close();
        }
    }
}
