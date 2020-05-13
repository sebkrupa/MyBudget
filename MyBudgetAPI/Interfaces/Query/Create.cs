using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBudgetAPI.Interfaces.Query
{
    public abstract class Create<T> where T : ICRUD_Fields
    {
        private string tableName;
        public Create() => tableName = this.GetType().Name;

        public void Add(T newItem)
        {
            string basic = string.Join(", ",newItem.CrudFields);
            List<string> items = new List<string>();
            foreach (var c in newItem.CrudFields)
                items.Add($"@{c}");

            using(var db = DB.DBContext())
            {
                db.Execute($"insert into {tableName} ({basic}) " +
                            $"values ({string.Join(", ",items)})", newItem);
            }
        }

    }
}
