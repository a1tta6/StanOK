using StanOK.Authorization.Model;
using StanOK.Models;
using StanOK.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace StanOK.Benches.ViewModel
{
    public class AddBenchViewModel : INotifyPropertyChanged
    {
        public MachineModel EditingBench = new MachineModel();
        public string Title { get; set; } 
        public string BenchType
        {
            get { return EditingBench.MachineType; }
            set { EditingBench.MachineType = value; NotifyPropertyChanged(); }
        }
        public string Country
        {
            get { return EditingBench.Country; }
            set { EditingBench.Country = value; NotifyPropertyChanged(); }
        }
        public string Brand
        {
            get { return EditingBench.Brand; }
            set { EditingBench.Brand = value; NotifyPropertyChanged(); }
        }
        public int Year
        {
            get { return EditingBench.Year; }
            set { EditingBench.Year = value; NotifyPropertyChanged(); }
        }
        public AddBenchViewModel(bool isNew)
        {
            if (isNew)
                Title = "Добавление станка";
            else Title = "Изменение станка";
        }
        public void Save()
        {
            UserContext userContext = new UserContext();
            userContext.Machines.Add(EditingBench);
            userContext.SaveChanges();
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
