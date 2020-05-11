using MyBudgetAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Model
{
    public class Expenses : IDate
    {
        public int id { get; set; }
        public double value { get; set; }
        public int subCategoryId { get; set; }
        public string comment { get; set; }
        public string date { get; set; }
        public DateTime? Date { get { return DateTime.Parse(date); } }
        public string ShortDate { get { return Date.Value.ToShortDateString(); } }
        public SubCategory SubCategory { get { return Read.SubCategory.GetSubCategory(subCategoryId); } }
        public string SubCategoryName { get { return SubCategory.name; } }
        public string CategoryName { get { return SubCategory.Category.name; } }
    }
}
