using MyBudgetAPI.Interfaces;

namespace MyBudgetAPI.Model
{
    public class Category : Interfaces.ICRUD_Fields
    {
        public int id { get; set; }
        public string name { get; set; }

        string[] ICRUD_Fields.Create => new string[] { "name" };
    }
}
