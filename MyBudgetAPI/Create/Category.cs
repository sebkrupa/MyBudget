using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Create
{
    public static class Category
    {
        public static void AddCategory(Model.Category category)
        {
            using (var db = DB.DBContext())
            {
                db.Execute("insert into Category (name) " +
                    "values (@name)", category);
            }
        }
    }
}
