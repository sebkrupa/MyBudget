using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Create
{
    public static class Monthly
    {
        public static void AddMonthly(Model.Monthly monthly)
        {
            using (var db = DB.DBContext())
            {
                db.Execute("insert into Monthly (subcategoryId, toSplit) " +
                    "values (@subcategoryId, @toSplit)", monthly);
            }
        }
    }
}
