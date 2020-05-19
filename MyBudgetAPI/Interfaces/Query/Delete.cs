using Dapper;

namespace MyBudgetAPI.Interfaces.Query
{
    public abstract class Delete<T> where T : ICRUD_Fields
    {
        private string tableName;
        public Delete() => tableName = this.GetType().Name;
        public void RemoveItem(T itemToRemove)
        {
            RemoveItem(itemToRemove.id);
            RemoveForeignKeys?.Invoke(itemToRemove);
        }

        public void RemoveItem(int id)
        {
            using (var db = DB.DBContext())
            {
                db.Execute($"delete from {tableName} where id={id}");
            }
        }

        public delegate void AdditionalRemove(T itemToRemove);
        public AdditionalRemove RemoveForeignKeys;
    }
}
