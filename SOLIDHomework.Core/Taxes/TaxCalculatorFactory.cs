using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.PriceCalculator;

namespace SOLIDHomework.Core.Taxes
{
    public static class TaxCalculatorFactory
    {
        private static readonly Dictionary<string, ITaxCalculator> _calculators =
            new Dictionary<string, ITaxCalculator>
            {
                { "US", new USTaxCalculator() },
                { "no-US", new OtherCountriesTaxCalculator() }
            };

        public static ITaxCalculator GetTaxCalculator(string countryType)
        {
            if (_calculators.TryGetValue(countryType, out var calculator))
            {
                return calculator;
            }
            else
            {
                throw new NotImplementedException($"There is not a tax calculator for the country code: {countryType}");
            }
        }
    }
}
