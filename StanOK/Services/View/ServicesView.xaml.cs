﻿using StanOK.Benches;
using StanOK.Repair.View;
using StanOK.Services.ViewModel;
using StanOK.UserData.ViewModel;
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

namespace StanOK.Services.View
{
    /// <summary>
    /// Логика взаимодействия для ServicesView.xaml
    /// </summary>


    public partial class ServicesView : Window
    {
        ServicesViewModel ViewModel;
        public ServicesView()
        {
            InitializeComponent();
            ViewModel = new ServicesViewModel();
            DataContext = ViewModel;
        }

        private void GetMachines_Click(object sender, RoutedEventArgs e)
        {
            BenchesView benchesView = new BenchesView();
            benchesView.ShowDialog(); 
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Refresh();
        }
    }
}
