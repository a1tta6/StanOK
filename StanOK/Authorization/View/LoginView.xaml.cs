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
using StanOK.Authorization.Model;
using StanOK.Authorization.ViewModel;

namespace StanOK.Authorization.View
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        AuthorizationViewModel ViewModel;
        public LoginView()
        {
            InitializeComponent();
            ViewModel = new AuthorizationViewModel();
            DataContext = ViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Authorizaton())
            {
                MainPage.View.MainPageView mainPageView = new MainPage.View.MainPageView();
                mainPageView.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверные данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error );
            }
        }
    }
}
