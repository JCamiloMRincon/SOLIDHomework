using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLIDHomework.Core.Exceptions;
using SOLIDHomework.Core.Model;

namespace SOLIDHomework.Core.Payment
{
    public class PaymentProcessor
    {
        public void ChargeCard(PaymentDetails paymentDetails, ShoppingCart cart, PaymentServiceType paymentServiceType)
        {
            try
            {
                IPayment payment = PaymentFactory.GetPaymentService(paymentServiceType);
                string serviceResponse = payment.Charge(cart.TotalAmount(), new CreditCart()
                {
                    CardNumber = paymentDetails.CreditCardNumber,
                    ExpiryDate = paymentDetails.ExpiryDate,
                    NameOnCard = paymentDetails.CardholderName
                });

                if (!serviceResponse.Contains("200OK") && !serviceResponse.Contains("Success"))
                {
                    throw new Exception(String.Format("Error on charge : {0}", serviceResponse));
                }
            }
            catch (AccountBalanceMismatchException ex)
            {
                throw new OrderException("The card gateway rejected the card based on the address provided.", ex);
            }
            catch (Exception ex)
            {
                throw new OrderException("There was a problem with your card.", ex);
            }
        }
    }
}
