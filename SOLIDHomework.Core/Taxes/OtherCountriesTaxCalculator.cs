using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Taxes
{
    public class OtherCountriesTaxCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal total)
        {
            total *= 1.1M;
            return total;
        }
    }
}
