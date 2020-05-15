using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyBudget_Core.View.Statistics
{
    /// <summary>
    /// Interaction logic for AverageExpenditure.xaml
    /// </summary>
    public partial class AverageExpenditure : UserControl
    {
        public AverageExpenditure()
        {
            InitializeComponent();
        }

        private void Button_AddToChart(object sender, RoutedEventArgs e)
        {
            var selectedSubCategory = (MyBudgetAPI.Model.SubCategory)categoryPicker.cbxSubCategory.SelectedItem;
            var list = new MyBudgetAPI.Read.Expenses().GetAll().Where(x=>x.subCategoryId == selectedSubCategory.id);
            //list = list.Where(x=>x.subCategoryId == )
            double[] monthlyExpenses = new double[12];
            for (int i = 1; i < 12; i++)
            {
                double sum = list.Where(x => x.Date.Month == i).Sum(x => x.value);
                monthlyExpenses[i - 1] = sum;
            }

            mainChart.AddToChart(selectedSubCategory.name, monthlyExpenses);
        }

        private void Button_RemoveFromChart(object sender, RoutedEventArgs e)
        {
            var selectedSubCategory = (MyBudgetAPI.Model.SubCategory)categoryPicker.cbxSubCategory.SelectedItem;
            mainChart.RemoveFromChart(selectedSubCategory.name);
            //mainChart.SetXLabels(new string[] { "dupa", "dupa1" });
        }
    }
}
