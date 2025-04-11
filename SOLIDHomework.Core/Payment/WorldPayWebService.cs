using System;

namespace SOLIDHomework.Core.Payment
{
    public class WorldPayWebService : IPaymentWebService
    {
        public string Charge(PaymentRequest request)
        {
            var bankPaymentRequest = request as BankPaymentRequest;

            if (bankPaymentRequest is null)
            {
                throw new NullReferenceException("It is not possible to charge the payment request because there is not the required information.");
            }
            else 
            {
                return "Success";
            }
        }
    }
}