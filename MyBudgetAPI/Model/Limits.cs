using MyBudgetAPI.Interfaces;

namespace MyBudgetAPI.Model
{
    public class Limits : ICRUD_Fields
    {
        public int id { get; set; }
        public double valueLimit { get; set; }
        public int subCategoryId { get; set; }
        string[] ICRUD_Fields.Create => new string[] { "valueLimit", "subCategoryId" };
    }
}
