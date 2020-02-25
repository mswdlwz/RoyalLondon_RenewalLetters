using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalLondon_RenewalLetters
{
    public static class ValidData
    {
        public static int ChkCustID(string id)
        {
            if (int.TryParse(id, out _))
                return Convert.ToInt32(id);
            else
                return 0;
        }

        public static decimal CheckPaymentAmnt(string paymentIn)
        {
            if (decimal.TryParse(paymentIn, out _))
                return Convert.ToDecimal(paymentIn);
            else
                return 0;
        }

        public static decimal CheckAnnualPrem(string premiumIn)
        {
            if (decimal.TryParse(premiumIn, out _))
                return Convert.ToDecimal(premiumIn);
            else
                return 0;
        }
    }
}
