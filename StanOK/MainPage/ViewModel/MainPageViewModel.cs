using StanOK.Models;
using StanOK.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StanOK.MainPage
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        UserContext context = new UserContext();
        public List<RepairTypeModel> RepairTypesList => context.RepairTypes.ToList();
        Visibility _showUserVisibility;
        public Visibility ShowUserVisibility
        {
            get { return _showUserVisibility; }
            set { _showUserVisibility = value; NotifyPropertyChanged(); }
        }
        public MainPageViewModel(bool isAdmin) 
        {
            if (isAdmin) 
                ShowUserVisibility = Visibility.Visible;
            else
                ShowUserVisibility = Visibility.Collapsed;
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
