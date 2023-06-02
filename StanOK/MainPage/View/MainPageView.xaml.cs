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

namespace StanOK.MainPage.View
{
    /// <summary>
    /// Логика взаимодействия для MainPageView.xaml
    /// </summary>
    public partial class MainPageView : Window
    {
        public MainPageView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Repair.View.RepairView repairView = new Repair.View.RepairView();
            repairView.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UserData.View.UserDataView userdataView = new UserData.View.UserDataView();
            userdataView.Show();
        }
    }
}
