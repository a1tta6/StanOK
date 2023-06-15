using StanOK.Benches.ViewModel;
using StanOK.Models;
using StanOK.Services.ViewModel;
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
    /// Логика взаимодействия для AddServiceView.xaml
    /// </summary>
    public partial class AddServiceView : Window
    {
        AddServiceViewModel ViewModel;
        public AddServiceView()
        {
            InitializeComponent();
            ViewModel = new AddServiceViewModel(true, null);
            DataContext = ViewModel;
        }
        public AddServiceView(RepairModel EditingRepair)
        {
            InitializeComponent();
            ViewModel = new AddServiceViewModel(false, EditingRepair);
            DataContext = ViewModel;
        }

        private void CanselButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if ((ViewModel.SelectedBench==null) || (ViewModel.SelectedRepair == null))
            {
                MessageBox.Show("Присутствуют пустые поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Запись успешно сохранена!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                ViewModel.Save();
            }
            this.Close();
        }
    }
}
