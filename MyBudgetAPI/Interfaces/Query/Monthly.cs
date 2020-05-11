using System;
using System.Collections.Generic;
using System.Text;

namespace MyBudgetAPI.Interfaces.Query
{
    public interface IMonthly
    {
        public IEnumerable<T> GetMonthly<T>(int month);
    }
}
