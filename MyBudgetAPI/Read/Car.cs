using System;
using System.Linq;

namespace MyBudgetAPI.Read
{
    public class Car : Interfaces.Query.Read<Model.Car>
    {
        public double GetAverageBurn()
        {
            var all = base.GetAll();
            double sumKm = all.Sum(x => x.kmCounter);
            double sumLitres = all.Sum(x => x.litres);
            return Math.Round(sumLitres / (sumKm / 100), 2);
        }
    }
}
