using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLIDHomework.Core.PriceCalculator;
using SOLIDHomework.Core.Taxes;

namespace SOLIDHomework.Core
{
    //there are OCP and SOC violation
    //
    public class ShoppingCart
    {
        private readonly string country;
        private readonly List<OrderItem> orderItems;

        public ShoppingCart(string country, ITaxCalculator taxCalculator)
        {
            this.country = country;
            orderItems = new List<OrderItem>();
        }

        public IEnumerable<OrderItem> OrderItems
        {
            get { return orderItems; }
        }

        public void Add(OrderItem orderItem)
        {
            orderItems.Add(orderItem);
        }

        public decimal TotalAmount()
        {
            decimal total = 0;

            foreach (var orderItem in OrderItems)
            {
                IPriceCalculator calculator = PriceCalculatorFactory.GetPriceCalculator(orderItem.Type);
                total += calculator.Calculate(orderItem);
            }

            ITaxCalculator taxCalculator = TaxCalculatorFactory.GetTaxCalculator(country);
            total = taxCalculator.CalculateTax(total);
            return total;
        }      
    }
}
