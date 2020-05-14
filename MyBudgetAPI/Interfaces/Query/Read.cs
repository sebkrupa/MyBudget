using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace MyBudgetAPI.Interfaces.Query
{
    public abstract class Read<T> where T : class
    {
        private string tableName;
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
