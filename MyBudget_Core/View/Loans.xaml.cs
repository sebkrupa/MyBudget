using System.Windows.Controls;

namespace MyBudget_Core.View
{
    /// <summary>
    /// Interaction logic for Loans.xaml
    /// </summary>
    public partial class Loans : UserControl
    {
        public Loans()
        {
            InitializeComponent();
            PrepareControl();
            Model.Windows.RefreshView += PrepareControl;
        }

        private void PrepareControl() => dgridLoans.ItemsSource = ViewModel.Loans.GetLoans();
    }
}
