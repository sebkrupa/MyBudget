using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBudgetAPI.Interfaces.Query
{
    public abstract class Update<T> where T : ICRUD_Fields
    {
        private string tableName;
        public Update() => tableName = this.GetType().Name;

        public void UpdateItem(T itemToUpdate)
        {
            List<string> updateColumnsList = new List<string>();
            
            foreach (var c in itemToUpdate.Create)
                updateColumnsList.Add($"{c} = @{c}");

            using (var db = DB.DBContext())
            {
                db.Execute($"update {tableName} " +
                    $"set {string.Join(',',updateColumnsList)} " +
                    $"where id={itemToUpdate.id}");
            }
        }

    }
}
