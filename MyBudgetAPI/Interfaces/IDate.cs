using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyBudgetAPI.Interfaces
{
    public interface IDate
    {
        public DateTime Date { get; }
        public string ShortDate { get;}
    }
}
