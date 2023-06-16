using StanOK.Benches.View;
using StanOK.Benches.ViewModel;
using StanOK.MainPage;
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
using System.Text.RegularExpressions;

namespace StanOK.Benches
{
    /// <summary>
    /// Логика взаимодействия для BenchesView.xaml
    /// </summary>
    public partial class BenchesView : Window
    {
        BenchesViewModel ViewModel;
        bool IsAdmin;
        public BenchesView(bool isAdmin)
        {
            InitializeComponent();
            IsAdmin = isAdmin;
            ViewModel = new BenchesViewModel(IsAdmin);
            DataContext = ViewModel;
            ViewModel.LoadBenches();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddBenchView addBenchView = new AddBenchView();
            addBenchView.ShowDialog();
            ViewModel.LoadBenches();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedBench != null)
            {
                ViewModel.Delete();
                ViewModel.LoadBenches();
            }
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedBench == null)
            {
                MessageBox.Show("Станок не выбран!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            else
            {
                AddBenchView addBenchView = new AddBenchView(ViewModel.SelectedBench);
                addBenchView.ShowDialog();
                ViewModel.LoadBenches();
            }
        }
    }
}
