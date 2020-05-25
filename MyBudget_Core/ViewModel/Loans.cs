using System.Collections.Generic;

namespace MyBudget_Core.ViewModel
{
    public static class Loans
    {
        public static IEnumerable<Loan> GetLoans()
        {
            var list = new List<Loan>();
            var loans = new MyBudgetAPI.Read.Loan().GetAll();
            foreach (var c in loans)
            {
                list.Add(new Loan()
                {
                    id = c.id,
                    installment = c.monthlyPayments,
                    name = c.name,
                    total = c.value,
                    paid = c.AlreadyPaid
                });
            }
            return list;
        }
        public class Loan
        {
            public int id { get; set; }
            public string name { get; set; }
            public double total { get; set; }
            public double paid { get; set; }
            public double left { get { return total - paid; } }
            public double installment { get; set; }

        }
    }
}
