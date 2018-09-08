using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CatalogDesktopApp.Views;
using CatalogDesktopApp.ViewModels;

namespace CatalogDesktopApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MessageBus _messageBus;

        protected override void OnStartup(StartupEventArgs e)
        {
            _messageBus = MessageBus.Instance;
            _messageBus.Subscribe<ShowNoteWindow>(ShowNoteDialog);

            base.OnStartup(e);
        }

        private void ShowNoteDialog(ShowNoteWindow obj)
        {
            var newWindow = new InsertNote();
            var newWindowViewModel = new InsertNoteViewModel();

            newWindowViewModel.MaterieID = obj.MaterieID;
            newWindowViewModel.Materie = obj.Materia;

            newWindow.DataContext = newWindowViewModel;
            newWindow.ShowDialog();
        }
    }
}
