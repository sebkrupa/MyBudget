using Dapper;
using MyBudgetAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace MyBudgetAPI.Read
{
    public static class Category
    {
        public static List<Model.Category> AllCategories()
        {
            using (var db = DB.DBContext())
            {
                return db.Query<Model.Category>("select * from Category", new DynamicParameters()).ToList();
            }
        }

        public static Model.Category GetCategory(int id)
        {
            using (var db = DB.DBContext())
            {
                return db.Query<Model.Category>($"select * from SubCategory where id='{id}'", new DynamicParameters()).FirstOrDefault();
            }
        }
    }
}
