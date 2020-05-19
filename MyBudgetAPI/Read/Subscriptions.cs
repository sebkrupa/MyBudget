using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBudgetAPI.Read
{
    public class Subscriptions : Interfaces.Query.Read<Model.Subscriptions>
    {
        public IEnumerable<Model.Subscriptions> OrderedSubstriptionList()
        {
            List<Model.Subscriptions> result = new List<Model.Subscriptions>();
            var list = base.GetAll();
            foreach (var c in list.Where(x => x.timeFrameInMonths == 12))
            {
                c.Date = new DateTime(DateTime.Now.Year, c.Date.Month, c.Date.Day);
                if (c.Date < DateTime.Now) c.Date = c.Date.AddYears(1);
                result.Add(c);
            }

            foreach(var c in list.Where(x=>x.timeFrameInMonths == 1))
            {
                c.Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, c.Date.Day);
                if (c.Date < DateTime.Now) c.Date = c.Date.AddMonths(1);
                result.Add(c);
            }

            return result.OrderBy(x => x.Date);
        }
    }
}
