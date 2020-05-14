using Dapper;

namespace MyBudgetAPI.Delete
{
    public class Loan : Interfaces.Query.Delete<Model.Loan>
    {
        public void RemoveLoansBySubCategoryId(Model.SubCategory subCategory)
        {
            using (var db = DB.DBContext())
            {
                db.Execute($"delete from Loan where subCategoryId={subCategory.id}");
            }
        }
    }
}
