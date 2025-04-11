namespace SOLIDHomework.Core.Payment
{
    /// <summary>
    /// The <c>PaymentBase</c> abstract class is replaced by <c>IPayment</c> interface
    /// </summary>
    public interface IPayment
    {
        string Charge(decimal amount, CreditCart creditCart);
    }
}
