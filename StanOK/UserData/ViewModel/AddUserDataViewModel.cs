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

namespace StanOK.UserData.ViewModel
{
    public class AddUserDataViewModel : INotifyPropertyChanged
    {
        public LoginModel EditingUserData = new LoginModel();
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
            if (EditingUserData != null)
                EditingUserData = Login;
            if (isNew)
                Title = "Добавление пользователя";
            else Title = "Изменение пользователя";
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
            if (EditingUserData.Login != null)
            {

                userContext.Users.First(x => x.Login == EditingUserData.Login).Login = EditingUserData.Login;
                userContext.Users.First(x => x.Login == EditingUserData.Login).Password = EditingUserData.Password;
                userContext.Users.First(x => x.Login == EditingUserData.Login).Role = EditingUserData.Role;


                userContext.SaveChanges();

            }
            else
            {
                userContext.Users.Add(EditingUserData);
                userContext.SaveChanges();
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
