using StanOK.Benches.ViewModel;
using StanOK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        }
        public AddBenchView(MachineModel EditingMachine)
        {
            InitializeComponent();
            ViewModel = new AddBenchViewModel(false, EditingMachine);
            DataContext = ViewModel;
        }
        private void CanselButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if ((ViewModel.BenchType == null) || (ViewModel.Country == null) || (ViewModel.Brand == null) || (ViewModel.BenchType == "") || (ViewModel.Country == "") || (ViewModel.Brand == ""))
            {
                MessageBox.Show("Присутствуют пустые поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!((ViewModel.Year <= DateTime.Today.Year) && (ViewModel.Year >= 1600))) //валидация года
            {
                MessageBox.Show("Неверный формат года!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (ViewModel.Repairs<=0) //валидация количества ремонтов
            {
                MessageBox.Show("Неверный формат количества ремонтов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Запись успешно сохранена!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                ViewModel.Save();
                this.Close();
            }
        }
    }
}
