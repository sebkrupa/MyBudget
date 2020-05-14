using MyBudgetAPI.Interfaces;

namespace MyBudgetAPI.Model
{
    public class Loan : ICRUD_Fields
    {
        public int id { get; set; }
        public string name { get; set; }
        public int subCategoryId { get; set; }
        public double value { get; set; }
        public double monthlyPayments { get; set; }
        public SubCategory SubCategory { get { return new Read.SubCategory().GetSingle(subCategoryId); } }
        string[] ICRUD_Fields.Create => new string[] { "name", "subCategoryId", "value", "monthlyPayments" };
    }
}
