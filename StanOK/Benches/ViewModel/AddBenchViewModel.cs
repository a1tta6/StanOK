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

namespace StanOK.Benches.ViewModel
{
    public class AddBenchViewModel : INotifyPropertyChanged
    {
        public MachineModel EditingBench = new MachineModel();
        public string Title { get; set; }
        public string OperType { get; set; }

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
        public int Repairs
        {
            get { return EditingBench.Repairs; }
            set { EditingBench.Repairs = value; NotifyPropertyChanged(); }
        }
        public AddBenchViewModel(bool isNew, MachineModel EditingMachine)
        {
            if (EditingMachine != null)
                EditingBench = EditingMachine;
            if (isNew)
            {
                Title = "Добавление станка";
                OperType = "Добавить";
            }
            else
            {
                Title = "Изменение станка";
                OperType = "Изменить";
            }
        }
        public void Delete()
        {
            UserContext userContext = new UserContext();
            userContext.Machines.Remove(EditingBench);
            userContext.SaveChanges();
        }
        public void Save()
        {
            UserContext userContext = new UserContext();
            if (EditingBench.Id > 0)
            {

                userContext.Machines.First(x => x.Id == EditingBench.Id).Brand = EditingBench.Brand;
                userContext.Machines.First(x => x.Id == EditingBench.Id).MachineType = EditingBench.MachineType;
                userContext.Machines.First(x => x.Id == EditingBench.Id).Country = EditingBench.Country;
                userContext.Machines.First(x => x.Id == EditingBench.Id).Year = EditingBench.Year;
                userContext.Machines.First(x => x.Id == EditingBench.Id).Repairs = EditingBench.Repairs;

                userContext.SaveChanges();

            }
            else
            {
                userContext.Machines.Add(EditingBench);
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
