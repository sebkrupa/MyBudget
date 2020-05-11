using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Read
{
    public static class Monthly
    {
        /// <summary>
        /// Zwraca listę wszystkich podkategorii, które wliczają się do miesięcznych wydatków
        /// </summary>
        /// <returns></returns>
        public static List<Model.Monthly> AllMonthly()
        {
            using (var db = DB.DBContext())
            {
                return db.Query<Model.Monthly>("select * from Monthly", new DynamicParameters()).ToList();
            }
        }

        public static Model.Monthly GetMonthly(int id)
        {
            using (var db = DB.DBContext())
            {
                return db.Query<Model.Monthly>($"select * from Monthly where id='{id}'", new DynamicParameters()).FirstOrDefault();
            }
        }
    }
}
