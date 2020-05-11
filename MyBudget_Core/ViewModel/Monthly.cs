using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyBudget_Core.ViewModel
{
    internal class Monthly : Interfaces.StandardUC
    {
        private double sumOfExpensesToSplit = 0;
        private View.Monthly UC { get; set; }

        internal Monthly() : base(new MyBudgetAPI.Read.Expenses().GetAll())
        {
            UC = new View.Monthly();
            base.cbxDates = UC.cbxDates;
            base.control = UC.listMonthly;
            base.SetComboBox();
            UC.txtDivide.TextChanged += (s, e) => DivideSumOfExpenses();
        }

        internal override void PopulateList(DateTime date)
        {
            sumOfExpensesToSplit = 0;
            UC.listMonthly.Items.Clear();
            var monthly = new MyBudgetAPI.Read.Monthly().GetAll();
            foreach (var c in monthly)
                UC.listMonthly.Items.Add(lvItem(c.SubCategory.name, GetSum(c.subcategoryId, date), c.ToSplit));
            DivideSumOfExpenses();
        }

        private void DivideSumOfExpenses()
        {
            UC.txtDivideSum.Text = "0";
            if (sumOfExpensesToSplit > 0)
                UC.txtDivideSum.Text = Math.Round(sumOfExpensesToSplit / ParseDivision(), 2).ToString() + " zł";
        }

        private int ParseDivision()
        {
            int divide = 1;

            if (!string.IsNullOrWhiteSpace(UC.txtDivide.Text))
                if (int.TryParse(UC.txtDivide.Text, out int result))
                    if (result > 0) return result;
            return divide;
        }

        private double GetSum(int subcategoryId, DateTime month)
        {
            double sum = 0;
            foreach (var c in new MyBudgetAPI.Read.Expenses().GetAll().Where(x => x.subCategoryId == subcategoryId && x.Date.Month == month.Month))
                sum += c.value;
            return sum;
        }

        private ListViewItem lvItem(string name, double value, bool toSplit)
        {
            ListViewItem item = new ListViewItem();
            item.Content = name + " - " + value;
            if (toSplit)
            {
                item.FontWeight = FontWeights.Bold;
                sumOfExpensesToSplit += value;
            }
            if (value == 0) item.Background = Brushes.Red;
            return item;
        }

        internal override UserControl GetUC() => UC;


    }
}
