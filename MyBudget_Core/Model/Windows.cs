using System;
using System.Collections.Generic;
using System.Text;

namespace MyBudget_Core.Model
{
    public static class Windows
    {
        public static MainWindow MainWindow { get; set; }
        public static void RefreshData()
        {
            MainWindow.tabExpenses.Content = new ViewModel.History(new MyBudgetAPI.Read.Expenses().GetAll()).GetUC();
            MainWindow.tabIncome.Content = new ViewModel.History(new MyBudgetAPI.Read.Income().GetAll(),false).GetUC();
            MainWindow.tabMonthly.Content = new ViewModel.Monthly().GetUC();
        }
    }
}
