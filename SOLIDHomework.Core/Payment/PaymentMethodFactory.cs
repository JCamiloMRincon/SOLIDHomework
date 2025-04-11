using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.PriceCalculator;

namespace SOLIDHomework.Core.Payment
{
    public static class PaymentMethodFactory
    {
        private static readonly Dictionary<PaymentMethod, IPaymentMethod> _methods =
            new Dictionary<PaymentMethod, IPaymentMethod>
            {
                { PaymentMethod.CreditCard, new CreditCardPaymentMethod() },
                { PaymentMethod.OnlineOrder, new OnlineOrderPaymentMethod() }
            };

        public static IPaymentMethod GetPaymentMethod(PaymentMethod method)
        {
            if (_methods.TryGetValue(method, out var paymentMethod))
            {
                return paymentMethod;
            }
            else
            {
                throw new NotImplementedException($"There is not a payment method which name is: {paymentMethod}");
            }
        }
    }
}
