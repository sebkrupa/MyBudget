using Dapper;
using System.Collections.Generic;

namespace MyBudgetAPI.Interfaces.Query
{
    public abstract class Create<T> where T : ICRUD_Fields
    {
        private string tableName;
        public Create() => tableName = this.GetType().Name;

        public void Add(T newItem)
        {
            string basic = string.Join(", ", newItem.Create);
            List<string> items = new List<string>();
            foreach (var c in newItem.Create)
                items.Add($"@{c}");

            using (var db = DB.DBContext())
            {
                db.Execute($"insert into {tableName} ({basic}) " +
                            $"values ({string.Join(", ", items)})", newItem);
            }
        }

    }
}
