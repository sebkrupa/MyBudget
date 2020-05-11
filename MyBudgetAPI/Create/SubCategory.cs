using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Create
{
    public static class SubCategory
    {
        public static void AddSubCategory(Model.SubCategory subCategory)
        {
            using (var db = DB.DBContext())
            {
                db.Execute("insert into SubCategory (name, categoryId) " +
                    "values (@name, @categoryId)", subCategory);
            }
        }
    }
}
