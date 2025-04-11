using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Payment
{
    public class TokenPaymentRequest : PaymentRequest
    {
        public string Token {  get; set; }

        public TokenPaymentRequest(decimal Amount, CreditCart CreditCart, string Token) : base(Amount, CreditCart)
        {
            this.Token = Token;
        }
    }
}
