using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Create
{
    public static class Expense
    {
        public static void AddExpense(Model.Expenses expense)
        {
            using (var db = DB.DBContext())
            {
                db.Execute("insert into Expenses (value, date, comment, subcategoryId) " +
                    "values (@value, @date, @comment, @subcategoryId)", expense);
            }
        }
    }

    public class Expenses : Interfaces.Query.Create<Model.Expenses>
    {

    }
}
