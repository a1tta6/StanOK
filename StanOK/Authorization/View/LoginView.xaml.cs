using System;
using System.Collections.Generic;
using System.Data;
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
using StanOK.Utils;

namespace StanOK.Authorization.View
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_login.Text.Length > 0)   
            {
                if (password.Password.Length > 0)         
                { 
                    UserContext context = new UserContext();
                    var User = context.Users.FirstOrDefault(x => x.Login == textBox_login.Text && x.Password == password.Password);
                    if (User != null)
                    {
                        MessageBox.Show("Пользователь авторизовался", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                        MainPage.View.MainPageView mainPageView = new MainPage.View.MainPageView();
                        mainPageView.Show();
                        this.Close();
                    }
                    else MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); 
                }
                else MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);  
            }
            else MessageBox.Show("Введите логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
    }
}
