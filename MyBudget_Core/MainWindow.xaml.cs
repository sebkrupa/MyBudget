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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyBudget_Core
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Model.Windows.MainWindow = this;
            Model.Windows.RefreshData();
        }
        private void MenuItem_RefreshData(object sender, RoutedEventArgs e) => Model.Windows.RefreshData();

        private void MenuItem_ChangeDB(object sender, RoutedEventArgs e)
        {
            DB.GetNewDBPath();
            Model.Windows.RefreshData();
        }
    }
}
