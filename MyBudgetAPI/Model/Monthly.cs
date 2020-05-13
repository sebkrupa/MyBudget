using MyBudgetAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Model
{
    public class Monthly : ICRUD_Fields
    {
        public int id { get; set; }
        public int subCategoryId { get; set; }
        public int toSplit { get; set; }
        public bool ToSplit
        {
            get
            {
                if (toSplit == 0) return false;
                return true;
            }
        }
        public SubCategory SubCategory { get { return new Read.SubCategory().GetSingle(subCategoryId); } }
        string[] ICRUD_Fields.Create => new string[] { "subCategoryId", "toSplit" };
    }
}
