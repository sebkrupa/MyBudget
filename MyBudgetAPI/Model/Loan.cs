using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Model
{
    public class Loan
    {
        public int id { get; set; }
        public string name { get; set; }
        public int subcategoryId { get; set; }
        public double value { get; set; }
        public double monthlyPayments { get; set; }
        public SubCategory SubCategory { get { return Read.SubCategory.GetSubCategory(subcategoryId); } }

    }
}
