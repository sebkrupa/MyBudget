using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudgetAPI.Read
{
    public static class SubCategory
    {
        public static List<Model.SubCategory> AllSubCategories()
        {
            using (var db = DB.DBContext())
            {
                return db.Query<Model.SubCategory>("select * from SubCategory", new DynamicParameters()).ToList();
            }
        }

        public static Model.SubCategory GetSubCategory(int id)
        {
            using (var db = DB.DBContext())
            {
                return db.Query<Model.SubCategory>($"select * from SubCategory where id='{id}'", new DynamicParameters()).FirstOrDefault();
            }
        }

        public static List<Model.SubCategory> GetSubCategoriesBasedOnCategory(int categoryId)
        {
            using (var db = DB.DBContext())
            {
                return db.Query<Model.SubCategory>($"select * from SubCategory where categoryId='{categoryId}'", new DynamicParameters()).ToList();
            }
        }
    }
}
