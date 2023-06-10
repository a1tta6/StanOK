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
        public LoginModel SelectedUser { get; set; }
        private List<LoginModel> _usersList;
        public List<LoginModel> UsersList
        {
            get { return _usersList; }
            set { _usersList = value; NotifyPropertyChanged(); }
        }
        public void Delete()
        {
            UserContext userContext = new UserContext();
            userContext.Users.Remove(userContext.Users.First(x => x.Login == SelectedUser.Login));
            userContext.SaveChanges();
        }
        public void LoadUsers()
        {
            UsersList = context.Users.ToList();
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
