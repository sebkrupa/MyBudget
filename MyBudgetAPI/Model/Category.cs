using MyBudgetAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Model
{
    public class Category : Interfaces.ICRUD_Fields
    {
        public int id { get; set; }
        public string name { get; set; }

        string[] ICRUD_Fields.Create => new string[] { "name" };
    }
}
