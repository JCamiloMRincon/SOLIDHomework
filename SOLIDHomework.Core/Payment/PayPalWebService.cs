using System;

namespace SOLIDHomework.Core.Payment
{
    public class PayPalWebService : IPaymentWebService
    {
        //web based service
        public string GetTransactionToken(string accountName, string password)
        {
            return "Something";
        }

        public string Charge(PaymentRequest request)
        {
            var bankPaymentRequest = request as TokenPaymentRequest;

            if (bankPaymentRequest is null)
            {
                throw new NullReferenceException("It is not possible to charge the payment request because there is not the required information.");
            }
            else
            {
                return "200OK";
            }
        }
    }
}