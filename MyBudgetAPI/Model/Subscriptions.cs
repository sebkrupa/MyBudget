using MyBudgetAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBudgetAPI.Model
{
    public class Subscriptions : ICRUD_Fields
    {
        public int id { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public int timeFrameInMonths { get; set; }
        public string comment { get; set; }
        public decimal value { get; set; }
        public DateTime Date { get { return DateTime.Parse(date); } set { date = value.ToString(); } }
        string[] ICRUD_Fields.Create => new string[] { "name", "date", "timeFrameInMonths", "comment", "value" };
    }
}
