using MyBudgetAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Model
{
    public class Income : IHistory, ICRUD_Fields
    {
        public int id { get; set; }
        public double value { get; set; }
        public string date { get; set; }
        public string comment { get; set; }
        public int incomeTypeId { get; set; }
        public DateTime Date { get { return DateTime.Parse(date); } }
        public string ShortDate { get { return Date.ToShortDateString(); } }
        public IncomeCategory IncomeType { get { return new Read.IncomeCategory().GetSingle(incomeTypeId); } }
        public string CategoryName { get { return IncomeType.name; } }
        public string SubCategoryName => null;
        string[] ICRUD_Fields.Create => new string[] {"value", "date", "comment", "incomeTypeId" };

        public Income() { }
        public Income(double _value, string _date, string _comment, int _incomeTypeId)
        {
            value = _value;
            date = _date;
            comment = _comment;
            incomeTypeId = _incomeTypeId;
        }
}
}
