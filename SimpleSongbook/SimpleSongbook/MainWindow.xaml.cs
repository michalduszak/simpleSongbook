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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleSongbook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _darkmode = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            Add addWindow = new Add();
            addWindow.ShowDialog();

        }

        private void Darkmode(object sender, RoutedEventArgs e)
        {
            if (_darkmode)
            {

            }
        }
    }
}
