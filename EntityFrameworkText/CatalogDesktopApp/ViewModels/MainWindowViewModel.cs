﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;

using CatalogDesktopApp.Annotations;

    using System.Windows;
    using System.Windows.Input;

namespace CatalogDesktopApp.ViewModels
{

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private bool _test = true;

        public MainWindowViewModel()
        {
            MyClickCommand = new RelayCommand(ClickCommand, CanClickCommand);

            My2ClickCommand = new RelayCommand(OtherClickCommand);
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
            MessageBox.Show("Hello!");

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