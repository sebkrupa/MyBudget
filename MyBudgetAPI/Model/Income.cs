using MyBudgetAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Model
{
    public class Income :IDate
    {
        public int id { get; set; }
        public double value { get; set; }
        public string date { get; set; }
        public string comment { get; set; }
        public int incomeTypeId { get; set; }
        public DateTime? Date { get { return DateTime.Parse(date); } }
        public string ShortDate { get { return Date.Value.ToShortDateString(); } }
        public IncomeType IncomeType { get { return Read.IncomeType.GetIncomeType(incomeTypeId); } }
    }
}
