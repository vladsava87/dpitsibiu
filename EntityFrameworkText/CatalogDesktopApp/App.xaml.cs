using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CatalogDesktopApp.MessageBus;
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
    }
}
