using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MyBudget_Core.Interfaces
{
    internal abstract class HistoryUC
    {
        /// <summary>
        /// list of items which will be populated
        /// </summary>
        internal ItemsControl control { get; set; }
        /// <summary>
        /// ComboBox with dates to select
        /// </summary>
        internal ComboBox cbxDates { get; set; }
        /// <summary>
        /// List of expenses/income
        /// </summary>
        private IEnumerable<MyBudgetAPI.Interfaces.IHistory> historyList { get; set; }

        /// <summary>
        /// after construct, you should assign control and cbxDates
        /// </summary>
        /// <param name="_historyList"></param>
        internal HistoryUC(IEnumerable<MyBudgetAPI.Interfaces.IHistory> _historyList)
        {
            historyList = _historyList;
            Model.Windows.RefreshView += RefreshList;
        }


        /// <summary>
        /// Set ComboBox with dates since oldest to today
        /// </summary>
        internal void SetComboBox()
        {
            cbxDates.ItemsSource = ViewModel.Dates.GetMonthsList(historyList).OrderByDescending(x => x.Date);
            cbxDates.DisplayMemberPath = "Name";
            cbxDates.SelectionChanged += (s, e) => RefreshList();
            cbxDates.SelectedIndex = 0;
        }

        /// <summary>
        /// Refresh control list after combobox selected item changed
        /// </summary>
        internal void RefreshList() => PopulateList(((Model.Months)cbxDates.SelectedItem).Date);

        /// <summary>
        /// Occurs after combobox item change. populate list of items which corresponds to the given date
        /// </summary>
        /// <param name="date"></param>
        /// <param name="control"></param>
        /// <param name="historyList"></param>
        internal virtual void PopulateList(DateTime date)
        {
            this.control.ItemsSource = null;
            this.control.ItemsSource = historyList.Where(x => x.Date.Month == date.Month && x.Date.Year == date.Year).OrderByDescending(x => x.Date);
        }

        internal virtual UserControl GetUC() => throw new NotImplementedException();
    }


}

