﻿using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace MyBudgetAPI.Read
{
    public class SubCategory : Interfaces.Query.Read<Model.SubCategory>
    {
        public List<Model.SubCategory> GetSubCategoriesBasedOnCategory(int categoryId)
        {
            using (var db = DB.DBContext())
            {
                return db.Query<Model.SubCategory>($"select * from SubCategory where categoryId='{categoryId}'", new DynamicParameters()).ToList();
            }
        }
    }
}
