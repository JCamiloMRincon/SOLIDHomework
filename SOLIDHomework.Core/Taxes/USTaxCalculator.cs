using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Taxes
{
    internal class USTaxCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal total)
        {
            total *= 1.2M;
            return total;
        }
    }
}
