using StanOK.UserData.ViewModel;
using StanOK.Models;
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

namespace StanOK.UserData.View
{
    /// <summary>
    /// Логика взаимодействия для AddUserDataView.xaml
    /// </summary>
    public partial class AddUserDataView : Window
    {
        AddUserDataViewModel ViewModel;
        public AddUserDataView()
        {
            InitializeComponent();
            ViewModel = new AddUserDataViewModel(true, null);
            DataContext = ViewModel;
            ViewModel.OperType = "Добавить";
        }
        public AddUserDataView(LoginModel EditingUserData)
        {
            InitializeComponent();
            ViewModel = new AddUserDataViewModel(false, EditingUserData);
            DataContext = ViewModel;
            ViewModel.OperType = "Изменить";
        }
        private void CanselButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Save();
            this.Close();
        }
    }
}
