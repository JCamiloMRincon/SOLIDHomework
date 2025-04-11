namespace SOLIDHomework.Core.Payment
{
    public interface IPaymentWebService
    {
        string Charge(PaymentRequest request);
    }
}
