using StanOK.Authorization.View;
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

namespace StanOK.MainPage.View
{
    /// <summary>
    /// Логика взаимодействия для MainPageView.xaml
    /// </summary>
    public partial class MainPageView : Window
    {
        MainPageViewModel ViewModel;

        bool IsAdmin;
        public MainPageView(bool IsAdmin)
        {
            InitializeComponent();
            this.IsAdmin = IsAdmin;
            ViewModel = new MainPageViewModel(this.IsAdmin);
            DataContext = ViewModel;
        }

        private void RepairType_Click(object sender, RoutedEventArgs e)
        {
            string type = (sender as Button).Content.ToString();
            Repair.View.RepairView repairView = new Repair.View.RepairView(type, IsAdmin);
            repairView.ShowDialog();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();
        }

        private void ShowUsersButton_Click(object sender, RoutedEventArgs e)
        {
            UserData.View.UserDataView userdataView = new UserData.View.UserDataView();
            bool? answ = userdataView.ShowDialog();
            if ((bool)answ)
            {
                LoginView loginView = new LoginView();
                loginView.Show();
                this.Close();
            }
        }
    }
}
