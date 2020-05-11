using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBudget_Core.ViewModel
{
    public static class Dates
    {

        public static DateTime GetOldestDate<T>(IEnumerable<MyBudgetAPI.Interfaces.IDate> date)
        {
            DateTime? oldestDate = date.OrderBy(x => x.Date).LastOrDefault().Date;
            return oldestDate ?? DateTime.Now.AddYears(-1);
        }
    }
}
