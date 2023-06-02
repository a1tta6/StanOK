﻿using StanOK.Authorization.ViewModel;
using StanOK.MainPage.View;
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

namespace StanOK.UserData.View
{
    /// <summary>
    /// Логика взаимодействия для UserDataView.xaml
    /// </summary>
    public partial class UserDataView : Window
    {
        UserDataViewModel ViewModel;
        public UserDataView()
        {
            InitializeComponent();
            ViewModel = new UserDataViewModel();
            DataContext = ViewModel;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainPageView mainPageWindow = new MainPageView();
            mainPageWindow.Show();
            this.Close();
        }
    }
}
