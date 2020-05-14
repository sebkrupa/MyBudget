namespace MyBudget_Core.Model
{
    public static class Windows
    {
        public static MainWindow MainWindow { get; set; }
        public static void RefreshData()
        {
            MainWindow.tabExpenses.Content = new ViewModel.History(new MyBudgetAPI.Read.Expenses().GetAll()).GetUC();
            MainWindow.tabIncome.Content = new ViewModel.History(new MyBudgetAPI.Read.Income().GetAll(), false).GetUC();
            MainWindow.tabMonthly.Content = new ViewModel.Monthly().GetUC();
            MainWindow.tabSettingsCategories.Content = new View.Settings.Categories();
            MainWindow.addAmountPanel.Children.Clear();
            MainWindow.addAmountPanel.Children.Add(new View.AmountAdd());
            MainWindow.tabSettingsIncomeCategories.Content = new View.Settings.IncomeCategories();
        }
    }
}
