using StanOK.Benches;
using StanOK.Benches.View;
using StanOK.Repair.View;
using StanOK.Services.ViewModel;
using StanOK.UserData.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StanOK.Services.View
{
    /// <summary>
    /// Логика взаимодействия для ServicesView.xaml
    /// </summary>


    public partial class ServicesView : Window
    {
        ServicesViewModel ViewModel;
        int RepairId;
        public ServicesView(int RepairId)
        {
            this.RepairId = RepairId;
            InitializeComponent();
            ViewModel = new ServicesViewModel(this.RepairId);
            DataContext = ViewModel;
        }

        private void GetMachines_Click(object sender, RoutedEventArgs e)
        {
            BenchesView benchesView = new BenchesView();
            benchesView.ShowDialog(); 
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            AddServiceView addServiceView = new AddServiceView(ViewModel.SelectedService);
            addServiceView.ShowDialog();
            ViewModel.LoadServices(RepairId);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddServiceView addServiceView = new AddServiceView();
            addServiceView.ShowDialog();
            ViewModel.LoadServices(RepairId);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteService();
            ViewModel.LoadServices(RepairId);
        }
    }
}
