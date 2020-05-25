using MyBudgetAPI.Interfaces;
using System;

namespace MyBudgetAPI.Model
{
    public class Car : ICRUD_Fields
    {
        public int id { get; set; }
        /// <summary>
        /// gdzie zatankowano
        /// </summary>
        public string station { get; set; }
        /// <summary>
        /// ile zatankowano
        /// </summary>
        public double litres { get; set; }
        /// <summary>
        /// ile zapłacono
        /// </summary>
        public double paid { get; set; }
        public string date { get; set; }
        public string comment { get; set; }
        /// <summary>
        /// ile przejechano na baku
        /// </summary>
        public double kmCounter { get; set; }

        public double avgPerformance { get { return Math.Round(litres / (kmCounter / 100), 2); } }
        public double litrePrice { get { return Math.Round(paid / litres, 2); } }
        public DateTime Date { get { return DateTime.Parse(date); } }
        string[] ICRUD_Fields.Create => new string[] { "station", "litres", "paid", "date", "comment", "kmCounter" };
    }
}
