using System;

namespace MyBudgetAPI.Interfaces
{
    public interface IDate
    {
        public DateTime Date { get; }
        public string ShortDate { get; }
    }
}
