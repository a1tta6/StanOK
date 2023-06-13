using StanOK.Models;
using StanOK.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StanOK.Benches.ViewModel
{
    public class BenchesViewModel: INotifyPropertyChanged
    {
        UserContext context = new UserContext();
        public MachineModel SelectedBench { get; set; }
        private List<MachineModel> _benchesList;
        public List<MachineModel> BenchesList 
        { 
            get { return _benchesList; }
            set { _benchesList = value; NotifyPropertyChanged(); }
        }
        private Visibility _elementVisibility;
        public Visibility ElementVisibility
        {
            get { return _elementVisibility; }
            set { _elementVisibility = value; NotifyPropertyChanged(); }
        }
        public void Delete()
        {
            UserContext userContext = new UserContext();
            userContext.Machines.Remove(userContext.Machines.First(x=>x.Id == SelectedBench.Id));
            userContext.SaveChanges();
        }
        public void LoadBenches()
        {
            BenchesList = context.Machines.ToList();
        }
        public BenchesViewModel(bool IsAdmin)
        {
            if (IsAdmin)
                ElementVisibility = Visibility.Visible;
            else ElementVisibility = Visibility.Collapsed;
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
