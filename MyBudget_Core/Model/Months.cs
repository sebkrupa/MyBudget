using System;
using System.Collections.Generic;
using System.Text;

namespace MyBudget_Core.Model
{
    public class Months
    {
        public DateTime Date { get; set; }
        public string Name { get { return $"{Date.Month}/{Date.Year}"; } }
        public Months(DateTime date) => Date = date;
    }
}
