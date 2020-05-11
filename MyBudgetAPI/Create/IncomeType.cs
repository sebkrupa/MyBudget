using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Create
{
    public static class IncomeType
    {
        public static void AddIncomeType(Model.IncomeType incomeType)
        {
            using (var db = DB.DBContext())
            {
                db.Execute("insert into IncomeType (name) " +
                    "values (@name)", incomeType);
            }
        }
    }
}
