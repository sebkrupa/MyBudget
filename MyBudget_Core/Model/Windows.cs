using System;
using System.Windows.Threading;

namespace MyBudget_Core.Model
{
    public static class Windows
    {
        public static Action RefreshView;
        public static MainWindow MainWindow { get; set; }
        public static void RefreshData()
        {
            MainWindow.tabExpenses.Content = new ViewModel.History(new MyBudgetAPI.Read.Expenses().GetAll()).GetUC();
            MainWindow.tabIncome.Content = new ViewModel.History(new MyBudgetAPI.Read.Income().GetAll(), false).GetUC();
            MainWindow.tabMonthly.Content = new ViewModel.Monthly().GetUC();
        }

        public static async void RefreshAll()
        {
            string title = MainWindow.Title;
            MainWindow.Title = "Trwa aktualizacja cash flow";
            await Dispatcher.CurrentDispatcher.InvokeAsync(RefreshData);
            MainWindow.Title = "Odświeżam pozostałe okna";
            await Dispatcher.CurrentDispatcher.InvokeAsync(RefreshView);

            MainWindow.Title = title;
        }
    }
}
