using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Read
{
    public static class Expenses
    {
        public static IEnumerable<Model.Expenses> AllExpenses()
        {
            using (var db = DB.DBContext())
            {
                return db.Query<Model.Expenses>("select * from Expenses", new DynamicParameters());
            }
        }
        public static Model.Expenses GetExpenses(int id)
        {
            using (var db = DB.DBContext())
            {
                return db.Query<Model.Expenses>($"select * from Expenses where id='{id}'", new DynamicParameters()).FirstOrDefault();
            }
        }

        public static IEnumerable<Model.Expenses> GetMonthlyExpenses(int month) => AllExpenses().Where(x => x.Date.Value.Month == month);
    }
}
