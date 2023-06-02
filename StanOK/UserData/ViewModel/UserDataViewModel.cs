using StanOK.Authorization.Model;
using StanOK.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StanOK.UserData.ViewModel
{
    public class UserDataViewModel : INotifyPropertyChanged
    {
        UserContext context = new UserContext();
        public List<LoginModel> LoginModel => context.Users.ToList();

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


    }
}
