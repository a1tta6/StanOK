﻿using StanOK.MainPage.View;
using StanOK.Repair.ViewModel;
using StanOK.Services.View;
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

namespace StanOK.Repair.View
{
    /// <summary>
    /// Логика взаимодействия для RepairView.xaml
    /// </summary>
    public partial class RepairView : Window
    {
        RepairViewModel ViewModel;
        public RepairView(string type)
        {
            InitializeComponent();
            ViewModel = new RepairViewModel(type);
            DataContext = ViewModel;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Services_Click(object sender, RoutedEventArgs e)
        {
            ServicesView ServicesWindow = new ServicesView(ViewModel.Repair.Id);
            ServicesWindow.ShowDialog();
        }

        private void ChangeInfo_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Changing();
        }
    }
}
