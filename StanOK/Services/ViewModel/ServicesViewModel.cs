using StanOK.Authorization.Model;
using StanOK.Models;
using StanOK.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StanOK.Services.ViewModel
{
    public class ServicesViewModel: INotifyPropertyChanged
    {
        UserContext context = new UserContext();
        public List<RepairModel> RepairModel => context.Repairs.ToList();
        public ServicesViewModel()
        {
            RepairModel.ForEach(pair => { 
                pair.MachineName = context.Machines.FirstOrDefault(x=>x.Id == pair.MachineType).MachineType;
                pair.RepairName = context.RepairTypes.FirstOrDefault(x => x.Id == pair.RepairType).Repair_name;
            });
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
