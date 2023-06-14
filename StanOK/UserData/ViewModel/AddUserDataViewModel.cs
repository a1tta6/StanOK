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
        public bool Save()
        {
            bool bo = true;
            {
                if (Password != null)
                {
                    if (Password.Length >= 10)
                    {
                        bool fl_A = false;
                        bool fl_a = false;
                        bool fl_1 = false;
                        bool fl__ = false;
                        int a = Password.Length;
                        for (int i = 0; i < a; i++)
                        {
                            if ('A' <= Password[i] && Password[i] <= 'Z')
                            {
                                fl_A = true;
                            }
                            else if ('a' <= Password[i] && Password[i] <= 'z')
                            {
                                fl_a = true;
                            }
                            else if ('0' <= Password[i] && Password[i] <= '9')
                            {
                                fl_1 = true;
                            }
                            else 
                            { 
                                fl__ = true; 
                            }
                        }
                        bo = fl_A && fl_a && fl_1 && fl__;
                    }
                    else bo = false;
                }
                else bo = false;
            }
            UserContext userContext = new UserContext();
            if (EditingUserData.Id != 0 && bo)
            {

                userContext.Users.First(x => x.Id == EditingUserData.Id).Login = EditingUserData.Login;
                userContext.Users.First(x => x.Id == EditingUserData.Id).Password = EditingUserData.Password;
                userContext.Users.First(x => x.Id == EditingUserData.Id).Role = EditingUserData.Role;
                userContext.SaveChanges();
                MessageBox.Show("Аутентификационные данные изменены. Для продолжения работы необходимо заново авторизоваться", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
            else
            {
                if (bo)
                {
                    userContext.Users.Add(EditingUserData);
                    userContext.SaveChanges();
                    MessageBox.Show("Аутентификационные данные добавлены. Для продолжения работы необходимо заново авторизоваться", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    return true;
                }
                else MessageBox.Show("Пароль не соответствует требованиям безопасности", "Ошибка пароля", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
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
