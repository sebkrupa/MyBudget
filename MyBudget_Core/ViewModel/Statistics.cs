using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBudget_Core.ViewModel
{
    public static class Statistics
    {
        public static double[] GetSubCategoryExpensesMonthly(int subCategoryId) => GetExpensesMonthly(new MyBudgetAPI.Read.Expenses().GetAll().Where(x => x.subCategoryId == subCategoryId));

        public static double[] GetCategoryExpensesMonthly(int categoryId) => GetExpensesMonthly(new MyBudgetAPI.Read.Expenses().GetAll().Where(x => x.SubCategory.categoryId == categoryId));

        private static double[] GetExpensesMonthly(IEnumerable<MyBudgetAPI.Model.Expenses> expenses)
        {
            double[] monthlyExpenses = new double[12];
            for (int i = 1; i < 12; i++)
            {
                double sum = expenses.Where(x => x.Date.Month == i).Sum(x => x.value);
                monthlyExpenses[i - 1] = sum;
            }
            return monthlyExpenses;
        }

        public static double[] GetSubCategoryExpensesYearly(int subCategoryId, int yearsBack) => GetExpensesYearly(new MyBudgetAPI.Read.Expenses().GetAll().Where(x => x.subCategoryId == subCategoryId), yearsBack);
        public static double[] GetCategoryExpensesYearly(int subCategoryId, int yearsBack) => GetExpensesYearly(new MyBudgetAPI.Read.Expenses().GetAll().Where(x => x.SubCategory.categoryId == subCategoryId), yearsBack);

        private static double[] GetExpensesYearly(IEnumerable<MyBudgetAPI.Model.Expenses> expenses, int yearsBack)
        {
            double[] yearlyExpenses = new double[yearsBack];
            for (int i = 0; i < yearsBack; i++)
            {
                double sum = expenses.Where(x => x.Date.Year == DateTime.Now.Year-i).Sum(x => x.value);
                yearlyExpenses[yearsBack - (i+1)] = sum;
            }
            return yearlyExpenses;
        }
    }
}
