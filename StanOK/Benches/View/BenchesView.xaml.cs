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

namespace StanOK.Benches
{
    /// <summary>
    /// Логика взаимодействия для BenchesView.xaml
    /// </summary>
    public partial class BenchesView : Window
    {
        BenchesViewModel ViewModel;
        public BenchesView()
        {
            InitializeComponent();
            ViewModel = new BenchesViewModel();
            DataContext = ViewModel;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
