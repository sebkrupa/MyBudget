using System;
using System.Collections.Generic;
using System.Text;

namespace MyBudgetAPI.Delete
{
    public class SubCategory : Interfaces.Query.Delete<Model.SubCategory>
    {
        public SubCategory()
        {
            base.RemoveForeignKeys += RemoveLoans;
        }

        private void RemoveLoans(Model.SubCategory subCategory)
        {

        }
    }
}
