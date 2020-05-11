using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Read
{
    public static class Loan
    {
        public static List<Model.Loan> AllLoan()
        {
            using (var db = DB.DBContext())
            {
                return db.Query<Model.Loan>("select * from Loan", new DynamicParameters()).ToList();
            }
        }

        public static Model.Loan GetLoan(int id)
        {
            using (var db = DB.DBContext())
            {
                return db.Query<Model.Loan>($"select * from Loan where id='{id}'", new DynamicParameters()).FirstOrDefault();
            }
        }
    }
}
