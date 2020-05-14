namespace MyBudgetAPI.Delete
{
    public class Category : Interfaces.Query.Delete<Model.Category>
    {
        public Category()
        {
            base.RemoveForeignKeys += new SubCategory().RemoveSubCategoriesRelatedToCategory;
        }
    }
}
