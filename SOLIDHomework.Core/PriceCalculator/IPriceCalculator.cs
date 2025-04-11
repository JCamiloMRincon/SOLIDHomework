using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.PriceCalculator
{
    public interface IPriceCalculator
    {
        decimal Calculate(OrderItem orderItem);
    }
}
