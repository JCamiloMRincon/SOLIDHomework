namespace SOLIDHomework.Core.Payment
{
    public class WorldPayPayment : IPayment
    {
        public WorldPayPayment(string appSetting)
        {
            throw new System.NotImplementedException();
        }

        //required for Auth;
        public string BankID { get; set; }
        public string DomenID { get; set; }

        public string Charge(decimal amount, CreditCart creditCart)
        {
            WorldPayWebService worldPayWebService = new WorldPayWebService();
            BankPaymentRequest bankPaymentRequest = new BankPaymentRequest(amount, creditCart, BankID, DomenID);

            string response = worldPayWebService.Charge(bankPaymentRequest);
            return response;
        }
    }
}