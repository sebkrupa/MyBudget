using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Create
{
    public static class Loan
    {
        public static void AddLoan(Model.Loan loan)
        {
            using (var db = DB.DBContext())
            {
                db.Execute("insert into Loan (name, value, subcategoryId, monthlyPayments) " +
                    "values (@name, @value, @subcategoryId, @monthlyPayments)", loan);
            }
        }
    }
}
