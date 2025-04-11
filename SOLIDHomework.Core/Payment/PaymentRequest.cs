namespace SOLIDHomework.Core.Payment
{
    public class PaymentRequest
    {
        public decimal Amount { get; set; }
        public CreditCart CreditCart { get; set; }

        public PaymentRequest(decimal Amount, CreditCart CreditCart) 
        {
            this.Amount = Amount;
            this.CreditCart = CreditCart;
        }
    }
}
