using MyBudgetAPI.Interfaces;
using System;

namespace MyBudgetAPI.Model
{
    public class Expenses : IHistory, ICRUD_Fields
    {
        public int id { get; set; }
        public double value { get; set; }
        public int subCategoryId { get; set; }
        public string comment { get; set; }
        public string date { get; set; }
        public DateTime Date { get { return DateTime.Parse(date); } }
        public string ShortDate { get { return Date.ToShortDateString(); } }
        public SubCategory SubCategory { get { return new Read.SubCategory().GetSingle(subCategoryId) ?? new SubCategory() { name = "-" }; } }
        public string SubCategoryName { get { return SubCategory.name ?? string.Empty; } }
        public string CategoryName { get { return SubCategory.Category == null ? string.Empty : SubCategory.Category.name; } }
        string[] ICRUD_Fields.Create => new string[] { "value", "subCategoryId", "comment", "date" };

        public Expenses() { }
        public Expenses(double _value, int _subCategoryId, string _comment, string _date)
        {
            value = _value;
            subCategoryId = _subCategoryId;
            comment = _comment;
            date = _date;
        }
    }
}
