using Dapper;
using MyBudgetAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Read
{
    public static class Income
    {
        public static List<Model.Income> GetAllIncome()
        {
            using (var db = DB.DBContext())
            {
                return db.Query<Model.Income>("select * from Income", new DynamicParameters()).ToList();
            }
        }

        public static Model.Income GetIncome(int id)
        {
            using (var db = DB.DBContext())
            {
                return db.Query<Model.Income>($"select * from Income where id='{id}'", new DynamicParameters()).FirstOrDefault();
            }
        }
    }
}
