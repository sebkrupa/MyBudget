using MyBudgetAPI.Interfaces;
using System;

namespace MyBudgetAPI.Model
{
    public class Car : ICRUD_Fields
    {
        public int id { get; set; }
        public string station { get; set; }
        public decimal capacity { get; set; }
        public decimal amount { get; set; }
        public string date { get; set; }
        public string comment { get; set; }
        public decimal totalKm { get; set; }
        public DateTime Date { get { return DateTime.Parse(date); } }
        string[] ICRUD_Fields.Create => new string[] { "station", "capacity", "amount", "date", "comment", "totalKm" };
    }
}
