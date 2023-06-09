using StanOK.Authorization.Model;
using StanOK.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StanOK.Authorization.ViewModel
{
    public class AuthorizationViewModel: INotifyPropertyChanged
    {
        public LoginModel LoginModel = new LoginModel();

        public string Login
        {
            get { return LoginModel.Login; }
            set { LoginModel.Login = value; NotifyPropertyChanged(); }
        }
        public string Password 
        {
            get { return LoginModel.Password; }
            set { LoginModel.Password = value; NotifyPropertyChanged(); }
        }
        public bool Authorizaton()
        {
            UserContext context = new UserContext();
            bool Success = context.Users.Any(x => x.Login == Login && x.Password == Password);
            
            return Success;
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
