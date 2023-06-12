using StanOK.Authorization.Model;
using StanOK.Models;
using StanOK.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StanOK.UserData.ViewModel
{
    public class AddUserDataViewModel : INotifyPropertyChanged
    {
        private LoginModel _loginModel { get; set; }

        public LoginModel EditingUserData
        {
            get { return _loginModel; }
            set { _loginModel = value; NotifyPropertyChanged(); }
        }
        public string Title { get; set; }
        public string OperType { get; set; }

        public string Login
        {
            get { return EditingUserData.Login; }
            set { EditingUserData.Login = value; NotifyPropertyChanged(); }
        }
        public string Password
        {
            get { return EditingUserData.Password; }
            set { EditingUserData.Password = value; NotifyPropertyChanged(); }
        }
        public string Role
        {
            get { return EditingUserData.Role; }
            set { EditingUserData.Role = value; NotifyPropertyChanged(); }
        }
        public AddUserDataViewModel(bool isNew, LoginModel Login)
        {
            if (Login != null)
                EditingUserData = Login;
            else EditingUserData = new LoginModel();
            if (isNew)
            {
                Title = "Добавление пользователя";
                OperType = "Добавить";
            }
            else
            {
                Title = "Изменение пользователя";
                OperType = "Изменить";
            }
        }
        public void Delete()
        {
            UserContext userContext = new UserContext();
            userContext.Users.Remove(EditingUserData);
            userContext.SaveChanges();
        }
        public void Save()
        {
            UserContext userContext = new UserContext();
            if (EditingUserData.Id != 0)
            {

                userContext.Users.First(x => x.Id == EditingUserData.Id).Login = EditingUserData.Login;
                userContext.Users.First(x => x.Id == EditingUserData.Id).Password = EditingUserData.Password;
                userContext.Users.First(x => x.Id == EditingUserData.Id).Role = EditingUserData.Role;
                userContext.SaveChanges();
                MessageBox.Show("Аутентификационные данные изменены. Для продолжения работы необходимо заново авторизоваться", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                userContext.Users.Add(EditingUserData);
                userContext.SaveChanges();
                MessageBox.Show("Аутентификационные данные добавлены. Для продолжения работы необходимо заново авторизоваться", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
