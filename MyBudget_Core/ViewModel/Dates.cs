using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBudget_Core.ViewModel
{
    public static class Dates
    {

        private static DateTime GetOldestDate(IEnumerable<MyBudgetAPI.Interfaces.IDate> date)
        {
            if(date.Count()>0)
            {
                DateTime? oldestDate = date.OrderBy(x => x.Date).FirstOrDefault().Date;
                return oldestDate ?? DateTime.Now.AddYears(-1);
            }
            return DateTime.Now;

        }

        public static List<Model.Months> GetMonthsList(IEnumerable<MyBudgetAPI.Interfaces.IDate> _date)
        {
            List<Model.Months> list = new List<Model.Months>();
            var date = GetOldestDate(_date);
            do
            {
                list.Add(new Model.Months(date));
                date = date.AddMonths(1);
            }
            while (date.Year < DateTime.Now.Year || (date.Year == DateTime.Now.Year && date.Month <= DateTime.Now.Month));
            return list;
        }
    }
}
