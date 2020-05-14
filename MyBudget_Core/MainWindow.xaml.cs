using System.Windows;

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
