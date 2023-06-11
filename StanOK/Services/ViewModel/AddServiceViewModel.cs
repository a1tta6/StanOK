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
using System.Windows.Input;

namespace StanOK.Services.ViewModel
{
    public class AddServiceViewModel: INotifyPropertyChanged
    {
        UserContext context = new UserContext();
        public string Title { get; set; }
        public string OperType { get; set; }
        private RepairModel _editingRepair;
        public RepairModel EditingRepair
        {
            get { return _editingRepair; }
            set { _editingRepair = value; NotifyPropertyChanged(); }
        }
        public List<MachineModel> BenchTypes { get; set; }
        public List<RepairTypeModel> RepairTypes { get; set; }
        private MachineModel _selectedMachine;
        private RepairTypeModel _selectedRepair;
        public MachineModel SelectedBench
        {
            get { return _selectedMachine; }
            set { _selectedMachine = value; NotifyPropertyChanged(); }
        }
        public RepairTypeModel SelectedRepair 
        { 
            get { return _selectedRepair; }
            set { _selectedRepair = value; NotifyPropertyChanged(); }
        }
        public DateTime DateBegin
        {
            get { return EditingRepair.DateBegin; }
            set { EditingRepair.DateBegin = value; NotifyPropertyChanged(); }
        }
        public string Comment
        {
            get { return EditingRepair.Comment; }
            set { EditingRepair.Comment = value; NotifyPropertyChanged(); }
        }
        public void Save()
        {
            UserContext userContext = new UserContext();

            EditingRepair.MachineType = SelectedBench.Id;
            EditingRepair.RepairType = SelectedRepair.Id;
            if (EditingRepair.Id > 0)
            {
                userContext.Repairs.First(x => x.Id == EditingRepair.Id).MachineType = EditingRepair.MachineType;
                userContext.Repairs.First(x => x.Id == EditingRepair.Id).RepairType = EditingRepair.RepairType;
                userContext.Repairs.First(x => x.Id == EditingRepair.Id).Comment = EditingRepair.Comment;
                userContext.Repairs.First(x => x.Id == EditingRepair.Id).DateBegin = EditingRepair.DateBegin;

                userContext.SaveChanges();
                MessageBox.Show("Услуга изменена", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                userContext.Repairs.Add(EditingRepair);
                userContext.SaveChanges();
                MessageBox.Show("Услуга добавлена", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        public AddServiceViewModel(bool isNew, RepairModel EditingRepair) 
        {
            BenchTypes = context.Machines.ToList();
            RepairTypes = context.RepairTypes.ToList();

            if (EditingRepair != null)
                this.EditingRepair = EditingRepair;
            else this.EditingRepair = new RepairModel();
            if (isNew)
            {
                Title = "Добавление услуги";
                OperType = "Добавить";
            }
            else
            {
                SelectedBench = BenchTypes.First(x => x.Id == EditingRepair.Machine.Id);
                SelectedRepair = RepairTypes.First(x => x.Id == EditingRepair.Repair.Id);
                Title = "Изменение услуги";
                OperType = "Изменить";
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
