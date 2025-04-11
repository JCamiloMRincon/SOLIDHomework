namespace SOLIDHomework.Core.Payment
{
    public class PayPalPayment : IPayment
    {
        public PayPalPayment(string appSetting, string s)
        {
            throw new System.NotImplementedException();
        }

        // required for Auth;
        public string AccountName { get; set; }
        public string Password { get; set; }

        public string Charge(decimal amount, CreditCart creditCart)
        {
            PayPalWebService payPalWebService = new PayPalWebService();
            string token = payPalWebService.GetTransactionToken(AccountName, Password);

            TokenPaymentRequest paymentRequest = new TokenPaymentRequest(amount, creditCart, token);
            string response = payPalWebService.Charge(paymentRequest);
            return response;
        }
    }
}