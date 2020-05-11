using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Create
{
    public static class Limits
    {
        public static void AddLimit(Model.Limits limits)
        {
            using (var db = DB.DBContext())
            {
                db.Execute("insert into Limits (valueLimit, subcategoryId) " +
                    "values ($valueLimit, $subcategoryId)", limits);
            }
        }
    }
}
