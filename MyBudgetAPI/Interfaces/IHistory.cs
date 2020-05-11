using System;
using System.Collections.Generic;
using System.Text;

namespace MyBudgetAPI.Interfaces
{
    public interface IHistory : IDate
    {
        public int id { get; set; }
        public double value { get; set; }
        public string CategoryName { get; }
        public string SubCategoryName { get; }
        public string comment { get; set; }
    }
}
