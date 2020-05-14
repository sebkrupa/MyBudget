using Dapper;

namespace MyBudgetAPI.Delete
{
    public class SubCategory : Interfaces.Query.Delete<Model.SubCategory>
    {
        public SubCategory()
        {
            base.RemoveForeignKeys += new Loan().RemoveLoansBySubCategoryId;
            base.RemoveForeignKeys += new Monthly().RemoveMonthlyBySubCategoryId;
        }

        public void RemoveSubCategoriesRelatedToCategory(Model.Category category)
        {
            using (var db = DB.DBContext())
            {
                db.Execute($"delete from SubCategory where categoryID={category.id}");
            }
        }
    }
}
