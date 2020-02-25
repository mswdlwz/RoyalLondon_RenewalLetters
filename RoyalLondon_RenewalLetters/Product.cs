using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalLondon_RenewalLetters
{
    public class Product
    {
        public string ProductName { get; set; }
        public decimal PayoutAmount { get; set; }
        public decimal AnnualPremium { get; set; }

        public Product(string productName, decimal payoutAmount, decimal annualPrem) => 
            (ProductName, PayoutAmount, AnnualPremium) = (productName, payoutAmount, annualPrem);
    }
}
