using System.Windows.Controls;

namespace MyBudget_Core.View.Car
{
    /// <summary>
    /// Interaction logic for Car.xaml
    /// </summary>
    public partial class Car : UserControl
    {
        public Car()
        {
            InitializeComponent();
            Model.Windows.RefreshView += RefreshTable;
            RefreshTable();
        }

        internal void RefreshTable()
        {
            dgridFuel.ItemsSource = null;
            dgridFuel.ItemsSource = new MyBudgetAPI.Read.Car().GetAll();
            txtAvg.Text = new MyBudgetAPI.Read.Car().GetAverageBurn().ToString() + " L";
        }
    }
}
