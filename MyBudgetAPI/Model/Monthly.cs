using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Model
{
    public class Monthly
    {
        public int id { get; set; }
        public int subcategoryId { get; set; }
        public int toSplit { get; set; }
        public bool ToSplit
        {
            get
            {
                if (toSplit == 0) return false;
                return true;
            }
        }
        public SubCategory SubCategory { get { return Read.SubCategory.GetSubCategory(subcategoryId); } }
    }
}
