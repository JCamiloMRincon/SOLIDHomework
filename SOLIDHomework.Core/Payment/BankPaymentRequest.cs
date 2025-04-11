using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Payment
{
    public class BankPaymentRequest : PaymentRequest
    {
        public string BankID { get; set; }
        public string DomenID { get; set; }

        public BankPaymentRequest(decimal Amount, CreditCart CreditCart, string BankID, string DomenID) : base(Amount, CreditCart) 
        { 
            this.BankID = BankID;
            this.DomenID = DomenID;
        }
    }
}
