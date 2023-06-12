using StanOK.Authorization.ViewModel;
using StanOK.UserData.View;
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
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserDataView addUserDataView = new AddUserDataView();
            bool? ans = addUserDataView.ShowDialog();
            ViewModel.LoadUsers();
            if ((bool)ans)
            {
                this.DialogResult = true;
                this.Close();
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            AddUserDataView addUserDataView = new AddUserDataView(ViewModel.SelectedUser);
            bool? ans = addUserDataView.ShowDialog();
            ViewModel.LoadUsers();
            if ((bool)ans)
            {
                this.DialogResult = true;
                this.Close();
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Delete();
            ViewModel.LoadUsers();
            this.DialogResult = true;
            this.Close();
        }
    }
}
