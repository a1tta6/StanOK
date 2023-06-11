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
using System.Windows;

namespace StanOK.Services.ViewModel
{
    public class ServicesViewModel : INotifyPropertyChanged
    {
        UserContext context = new UserContext();
        public RepairModel SelectedService { get; set; }
        private List<RepairModel> _repairModel;
        public List<RepairModel> RepairModel
        {
            get { return _repairModel; }
            set { _repairModel = value; NotifyPropertyChanged(); }
        }
        public ServicesViewModel()
        {
            LoadServices();
        }
        public void LoadServices()
        {
            RepairModel = context.Repairs.ToList();
            RepairModel.ForEach(pair => {
                pair.MachineName = context.Machines.FirstOrDefault(x => x.Id == pair.MachineType).MachineType;
                pair.RepairName = context.RepairTypes.FirstOrDefault(x => x.Id == pair.RepairType).Repair_name;
            });
        }
        public void DeleteService()
        {
            if (SelectedService != null) 
            {
                MessageBoxResult answer = MessageBox.Show("Вы уверены, что хотите удалить выбранную запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (answer == MessageBoxResult.Yes)
                {
                    context.Repairs.Remove(SelectedService);
                    context.SaveChanges();
                    MessageBox.Show("Запись удалена", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);

                }

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
