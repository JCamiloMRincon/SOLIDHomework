using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.PriceCalculator
{
    public class CreditCardPaymentMethod : IPriceCalculator
    {
        public decimal Calculate(OrderItem orderItem)
        {
            decimal unitDiscount = 0;
            decimal total = 0;

            //appply 20& discount for old seasons
            if (orderItem.SeassonEndDate <= DateTime.Now)
            {
                unitDiscount = 20;
            }

            total = orderItem.Amount * orderItem.Price * (1 - unitDiscount / 100m);
            return total;
        }
    }
}
