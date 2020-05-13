using Dapper;
using MyBudgetAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Create
{
    public class Income : Interfaces.Query.Create<Model.Income>
    {
        public void AddIncome(Model.Income income)
        {
            using (var db = DB.DBContext())
            {
                db.Execute("insert into Income (value, date, comment, incomeTypeId) " +
                    "values (@value, @date, @comment, @incomeTypeId)", income);
            }
        }
    }
}
