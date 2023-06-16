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
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; NotifyPropertyChanged(); }
        }
        public string Role
        {
            get { return EditingUserData.Role; }
            set { EditingUserData.Role = value; NotifyPropertyChanged(); }
        }
        public AddUserDataViewModel(bool isNew, LoginModel Login)
        {
            if (Login != null)
            {
                EditingUserData = Login;
                Password = EditingUserData.DecryptedPassword;
            }
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
        public bool ValidatePassword()
        {
            bool SuccessValidate = true;
            bool HasBigLetters = false;
            bool HasSmallLetters = false;
            bool HasDigit = false;
            bool HasOtherSymbols = false;
            if (Password != null)
            {
                if (Password.Length >= 10)
                {
                    int a = Password.Length;
                    for (int i = 0; i < a; i++)
                    {
                        if ('A' <= Password[i] && Password[i] <= 'Z')
                            HasBigLetters = true;
                        else if ('a' <= Password[i] && Password[i] <= 'z')
                            HasSmallLetters = true;
                        else if ('0' <= Password[i] && Password[i] <= '9')
                            HasDigit = true;
                        else
                            HasOtherSymbols = true;
                    }
                    SuccessValidate = HasBigLetters && HasSmallLetters && HasDigit && HasOtherSymbols;
                }
                else SuccessValidate = false;
            }
            else SuccessValidate = false;
            return SuccessValidate;
        }
        public bool Save()
        {
            UserContext userContext = new UserContext();
            bool PasswordIsOK = ValidatePassword();
            if (EditingUserData.Id != 0 && PasswordIsOK)
            {

                userContext.Users.First(x => x.Id == EditingUserData.Id).Login = EditingUserData.Login;
                userContext.Users.First(x => x.Id == EditingUserData.Id).Password = Encryption.Encrypt(Password);
                userContext.Users.First(x => x.Id == EditingUserData.Id).Role = EditingUserData.Role;
                userContext.SaveChanges();
                MessageBox.Show("Аутентификационные данные изменены. Для продолжения работы необходимо заново авторизоваться", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
            else
            {
                if (PasswordIsOK)
                {
                    EditingUserData.Password = Encryption.Encrypt(Password);
                    userContext.Users.Add(EditingUserData);
                    userContext.SaveChanges();
                    MessageBox.Show("Аутентификационные данные добавлены. Для продолжения работы необходимо заново авторизоваться", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    return true;
                }
                else MessageBox.Show("Пароль не соответствует требованиям безопасности. Пароль должен быть не менее 10 символов, содержать символы разного регистра, цифры и специальные символы", "Ошибка пароля", MessageBoxButton.OK, MessageBoxImage.Information);
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
