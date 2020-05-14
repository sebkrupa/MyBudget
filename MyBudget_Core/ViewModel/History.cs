using MyBudgetAPI.Interfaces;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MyBudget_Core.ViewModel
{
    internal class History : Interfaces.HistoryUC
    {
        private View.History UC { get; set; }
        private bool showSubCategory;
        public History(IEnumerable<IHistory> _HistoryList, bool ShowSubCategoryColumn = true) : base(_HistoryList)
        {
            showSubCategory = ShowSubCategoryColumn;
            UC = new View.History();
            base.cbxDates = UC.cbxMonth;
            base.control = UC.dgridHistory;
            base.SetComboBox();
            UC.menuRemove.Click += (s, e) =>
            {
                if (UC.dgridHistory.SelectedItem != null)
                    RemoveItem((IHistory)UC.dgridHistory.SelectedItem);
                Model.Windows.RefreshData();
            };
        }
        internal override UserControl GetUC()
        {
            if (!showSubCategory) UC.dgridSubCategory.Visibility = System.Windows.Visibility.Collapsed;
            return UC;
        }

        internal void RemoveItem(IHistory historyItem)
        {
            switch(historyItem)
            {
                case MyBudgetAPI.Model.Expenses e:
                    new MyBudgetAPI.Delete.Expenses().RemoveItem(e);
                    break;
                case MyBudgetAPI.Model.Income i:
                    new MyBudgetAPI.Delete.Income().RemoveItem(i);
                    break;
            }
        }
    }


}
