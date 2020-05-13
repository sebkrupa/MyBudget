using MyBudgetAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Model
{
    public class Limits : ICRUD_Fields
    {
        public int id { get; set; }
        public double valueLimit { get; set; }
        public int subCategoryId { get; set; }
        string[] ICRUD_Fields.Create => new string[] { "valueLimit", "subCategoryId" };
    }
}
