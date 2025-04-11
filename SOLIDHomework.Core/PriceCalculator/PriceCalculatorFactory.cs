using System;
using System.Collections.Generic;
using SOLIDHomework.Core.Model;

namespace SOLIDHomework.Core.PriceCalculator
{
    public static class PriceCalculatorFactory
    {
        private static readonly Dictionary<OrderItemType, IPriceCalculator> _calculators = 
            new Dictionary<OrderItemType, IPriceCalculator>
            {
                { OrderItemType.Unit, new CreditCardPaymentMethod() },
                { OrderItemType.Special, new SpecialPriceCalculator() },
                { OrderItemType.Weight, new WeightPriceCalculator() },
            };
        
        public static IPriceCalculator GetPriceCalculator(OrderItemType itemType)
        {
            if (_calculators.TryGetValue(itemType, out var calculator))
            {
                return calculator;
            }
            else
            {
                throw new NotImplementedException($"There is not a price calculator for the item type: {itemType}");
            }
        }
    }
}
