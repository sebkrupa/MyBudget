using Dapper;

namespace MyBudgetAPI.Delete
{
    public class Monthly : Interfaces.Query.Delete<Model.Monthly>
    {
        public void RemoveMonthlyBySubCategoryId(Model.SubCategory subCategory)
        {
            using (var db = DB.DBContext())
            {
                db.Execute($"delete from Monthly where subCategoryId={subCategory.id}");
            }
        }
    }
}
