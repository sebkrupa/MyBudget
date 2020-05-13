using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Read
{
    public class Expenses : Interfaces.Query.Read<Model.Expenses>
    {
        public IEnumerable<Model.Expenses> GetMonthlyExpenses(int month) => GetAll().Where(x => x.Date.Month == month);
    }
}
