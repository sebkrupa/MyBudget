using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Model
{
    public class SubCategory
    {
        public int id { get; set; }
        public int categoryId { get; set; }
        public string name { get; set; }
        public Category Category { get { return Read.Category.GetCategory(categoryId); } }

    }
}
