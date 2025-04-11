using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.PriceCalculator
{
    public class SpecialPriceCalculator : IPriceCalculator
    {
        public decimal Calculate(OrderItem orderItem)
        {
            decimal total = 0;
            total += orderItem.Amount * orderItem.Price;

            int setsOfFour = orderItem.Amount / 4;
            total -= setsOfFour * orderItem.Price; //discount on groups of 4 items
            return total;
        }
    }
}
