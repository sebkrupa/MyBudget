using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyBudget_Core.ViewModel
{
    public static class Subscriptions
    {
        public static IEnumerable<ListViewItem> GetSubscriptionsList()
        {
            List<ListViewItem> items = new List<ListViewItem>();
            var subs = new MyBudgetAPI.Read.Subscriptions().OrderedSubstriptionList();
            foreach (var c in subs)
            {
                var color = c.timeFrameInMonths == 12 ? Brushes.LightBlue : Brushes.Transparent;
                items.Add(new ListViewItem()
                {
                    Content = c.name + "   " + c.Date.ToShortDateString() + "   " + c.value + " zł",
                    Background = color,
                    ToolTip = c.comment,
                    Tag = c.id
                });
            }
            foreach (var c in items)
            {
                var contextMenu = new ContextMenu();
                var menu = new MenuItem();
                menu.Header = "Usuń";
                menu.Click += (s, e) => RemoveSubscriptionFromDB(Convert.ToInt32(c.Tag));
                contextMenu.Items.Add(menu);
                c.ContextMenu = contextMenu;
            }
            return items;
        }

        public static decimal GetSumOfYearlySubs()
        {
            var list = new MyBudgetAPI.Read.Subscriptions().GetAll();
            decimal sum = 0;
            foreach (var c in list)
                sum += (c.value * (12 / c.timeFrameInMonths));
            return sum;
        }


        private static void RemoveSubscriptionFromDB(int id) => new MyBudgetAPI.Delete.Subscriptions().RemoveItem(id);


        public static void AddNewSubscription(string name, DateTime dateStart, string comment, decimal value, int timeFrame)
        {
            MyBudgetAPI.Model.Subscriptions newSub = new MyBudgetAPI.Model.Subscriptions()
            {
                name = name,
                Date = dateStart,
                comment = comment,
                value = value,
                timeFrameInMonths = timeFrame
            };
            new MyBudgetAPI.Create.Subscriptions().Add(newSub);
        }
    }
}
