﻿using System;
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
using CatalogDesktopApp.ViewModels;

namespace CatalogDesktopApp.Views
{
    /// <summary>
    /// Interaction logic for ProfesoriWindow.xaml
    /// </summary>
    public partial class ProfesoriWindow : UserControl
    {
        public ProfesoriWindow()
        {
            InitializeComponent();
        }

        public ProfesoriWindow(ProfesoriWindowViewModel profesoriWindowViewModel)
        {
            InitializeComponent();
            this.DataContext = profesoriWindowViewModel;
        }
    }
}
