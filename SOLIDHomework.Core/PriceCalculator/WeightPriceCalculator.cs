using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.PriceCalculator
{
    public class WeightPriceCalculator : IPriceCalculator
    {
        public decimal Calculate(OrderItem orderItem)
        {
            decimal total = 0;

            total = orderItem.Amount * orderItem.Price /1000M;
            return total;
        }
    }
}
