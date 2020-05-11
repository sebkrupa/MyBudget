using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Read
{
    public static class IncomeType
    {
        public static List<Model.IncomeType> AllIncomeType()
        {
            using (var db = DB.DBContext())
            {
                return db.Query<Model.IncomeType>("select * from IncomeType", new DynamicParameters()).ToList();
            }
        }

        public static Model.IncomeType GetIncomeType(int id)
        {
            using (var db = DB.DBContext())
            {
                return db.Query<Model.IncomeType>($"select * from IncomeType where id='{id}'", new DynamicParameters()).FirstOrDefault();
            }
        }
    }
}
