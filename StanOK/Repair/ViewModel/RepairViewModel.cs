using StanOK.Models;
using StanOK.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StanOK.Repair.ViewModel
{
    public class RepairViewModel: INotifyPropertyChanged
    {
        string Type;
        public UserContext context = new UserContext();
        public RepairTypeModel Repair => context.RepairTypes.First(x => x.Repair_name == Type);
        private bool _isReadOnly, _canEdit;
        public bool IsReadOnly 
        { 
            get { return _isReadOnly; }
            set { _isReadOnly = value; NotifyPropertyChanged(); }
        }
        public bool CanEdit 
        {
            get { return _canEdit; }
            set { _canEdit = value; NotifyPropertyChanged(); }
        }

        private Visibility _elementVisibility;
        public Visibility ElementVisibility
        {
            get { return _elementVisibility; }
            set { _elementVisibility = value; NotifyPropertyChanged(); }
        }

        public RepairViewModel(string type, bool IsAdmin)
        {
            Type = type;
            IsReadOnly = true;

            if (IsAdmin)
                ElementVisibility = Visibility.Visible;
            else ElementVisibility = Visibility.Collapsed;
        }
        public void Changing()
        {
            context.SaveChanges();
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
