using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyBudget_Core
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool addHidden = false;
        public MainWindow()
        {
            InitializeComponent();
            Model.Windows.MainWindow = this;
            Model.Windows.RefreshData();
        }
        private void MenuItem_RefreshData(object sender, RoutedEventArgs e) => Model.Windows.RefreshAll();

        private void MenuItem_ChangeDB(object sender, RoutedEventArgs e)
        {
            DB.GetNewDBPath();
            Model.Windows.RefreshData();
        }

        private void TextBlock_HideShowAddPanel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            addHidden = !addHidden;
            if (addHidden)
            {
                panelAdd.Height = new GridLength(0);
                txtHide.Text = "^";
            }
            else
            {
                panelAdd.Height = new GridLength(1, GridUnitType.Star);
                txtHide.Text = "V";
            }
        }

        private void TextBlock_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e) => ((TextBlock)sender).Background = Brushes.LightBlue;

        private void TextBlock_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e) => ((TextBlock)sender).Background = Brushes.Transparent;

        private void MenuItem_CreateDB(object sender, RoutedEventArgs e) => DB.CreateNewDB();

        private void MenuItem_RefreshView(object sender, RoutedEventArgs e) => Model.Windows.RefreshView?.Invoke();
    }
}
