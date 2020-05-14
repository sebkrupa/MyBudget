using MyBudgetAPI.Interfaces;

namespace MyBudgetAPI.Model
{
    public class SubCategory : ICRUD_Fields
    {
        public int id { get; set; }
        public int categoryId { get; set; }
        public string name { get; set; }
        public Category Category { get { return new Read.Category().GetSingle(categoryId); } }
        string[] ICRUD_Fields.Create => new string[] { "categoryId", "name" };
    }
}
