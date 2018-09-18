using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CatalogDesktopApp.Views;
using CatalogDesktopApp.ViewModels;
using CatalogDesktopApp.Util;

namespace CatalogDesktopApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MessageBus _messageBus;

        public static Utilizator UtilizatorCurent;

        protected override void OnStartup(StartupEventArgs e)
        {
            _messageBus = MessageBus.Instance;
            _messageBus.Subscribe<ShowNoteWindow>(ShowNoteDialog);
            _messageBus.Subscribe<ShowAbsenteWindow>(ShowAbsenteDialog);
            _messageBus.Subscribe<ShowObservatiiWindow>(ShowObservatiiDialog);

            base.OnStartup(e);
        }

        private void ShowAbsenteDialog(ShowAbsenteWindow obj)
        {
            var newWindow = new InsertAbsenta();
            var newWindowViewModel = new InsertAbsentaViewModel();

            //newWindowViewModel.MaterieID = obj.MaterieID;
            //newWindowViewModel.Materie = obj.Materia;
            //newWindowViewModel.ProfesorID = obj.ProfesorID;
            //newWindowViewModel.Profesor = obj.Profesor;
            
            newWindow.DataContext = newWindowViewModel;
            newWindow.ShowDialog();
        }

        private void ShowNoteDialog(ShowNoteWindow obj)
        {
            var newWindow = new InsertNote();
            var newWindowViewModel = new InsertNoteViewModel();

            //newWindowViewModel.MaterieID = obj.MaterieID;
            //newWindowViewModel.Materie = obj.Materia;

            newWindow.DataContext = newWindowViewModel;
            newWindow.ShowDialog();
        }

        private void ShowObservatiiDialog(ShowObservatiiWindow obj)
        {
            var newWindow = new InsertObservatie();
            var newWindowViewModel = new InsertObservatieViewModel();

            newWindowViewModel.ProfesorID = obj.ProfesorID;
            newWindowViewModel.Profesor = obj.Profesor;

            newWindow.DataContext = newWindowViewModel;
            newWindow.ShowDialog();
        }
    }
}
