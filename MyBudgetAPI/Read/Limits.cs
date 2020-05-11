using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Read
{
    public static class Limits
    {
        public static List<Model.Limits> AllLimits()
        {
            using (var db = DB.DBContext())
            {
                return db.Query<Model.Limits>("select * from Limits", new DynamicParameters()).ToList();
            }
        }

        public static Model.Limits GetLimits(int id)
        {
            using (var db = DB.DBContext())
            {
                return db.Query<Model.Limits>($"select * from Limits where id='{id}'", new DynamicParameters()).FirstOrDefault();
            }
        }
    }
}
