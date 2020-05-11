using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MyBudgetAPI.Interfaces.Query
{
    public abstract class Read<T>
    {
        private string tableName;
        //private Type type;
        public Read() => tableName = this.GetType().Name;

        public IEnumerable<T> GetAll()
        {
            using (var db = DB.DBContext())
            {
                return db.Query<T>($"select * from {tableName}", new DynamicParameters());
            }
        }

        public T GetSingle(int id)
        {
            using (var db = DB.DBContext())
            {
                return db.Query<T>($"select * from {tableName} where id='{id}'", new DynamicParameters()).FirstOrDefault();
            }
        }
    }
}
