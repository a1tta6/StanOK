using StanOK.Benches.ViewModel;
using StanOK.Models;
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

namespace StanOK.Benches.View
{
    /// <summary>
    /// Логика взаимодействия для AddBenchView.xaml
    /// </summary>
    public partial class AddBenchView : Window
    {
        AddBenchViewModel ViewModel;
        public AddBenchView()
        {
            InitializeComponent();
            ViewModel = new AddBenchViewModel(true, null);
            DataContext = ViewModel;
            ViewModel.OperType = "Добавить";
        }
        public AddBenchView(MachineModel EditingMachine)
        {
            InitializeComponent();
            ViewModel = new AddBenchViewModel(false, EditingMachine);
            DataContext = ViewModel;
            ViewModel.OperType = "Изменить";
        }
        private void CanselButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Save();
            this.Close();
        }
    }
}
