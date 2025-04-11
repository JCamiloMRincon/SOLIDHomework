using System;
using System.Collections.Generic;
using System.Configuration;

namespace SOLIDHomework.Core.Payment
{
    public static class PaymentFactory
    {
        private static readonly Dictionary<PaymentServiceType, IPayment> _payments = 
            new Dictionary<PaymentServiceType, IPayment>() 
            {
                { PaymentServiceType.PayPal, new PayPalPayment(ConfigurationManager.AppSettings["accountName"], ConfigurationManager.AppSettings["password"]) },
                { PaymentServiceType.WorldPay, new WorldPayPayment(ConfigurationManager.AppSettings["BankID"]) }
            };

        public static IPayment GetPaymentService(PaymentServiceType serviceType)
        {
            if (_payments.TryGetValue(serviceType, out var payment))
            {
                return payment;
            }
            else
            {
                throw new NotImplementedException($"There is not a payment method for the service type: {serviceType}");
            }
        }
    }
}