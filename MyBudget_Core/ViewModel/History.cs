using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MyBudget_Core.ViewModel
{
    internal class History : Interfaces.StandardUC
    {
        private View.History UC { get; set; }
        private bool showSubCategory;
        public History(IEnumerable<MyBudgetAPI.Interfaces.IHistory> _HistoryList, bool ShowSubCategoryColumn = true) : base(_HistoryList)
        {
            showSubCategory = ShowSubCategoryColumn;
            UC = new View.History();
            base.cbxDates = UC.cbxMonth;
            base.control = UC.dgridHistory;
        }
        internal override UserControl GetUC()
        {
            if (!showSubCategory) UC.dgridSubCategory.Visibility = System.Windows.Visibility.Collapsed;
            base.SetComboBox();
            return UC;
        }
    }


}
