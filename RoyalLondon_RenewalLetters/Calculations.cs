using System;

namespace RoyalLondon_RenewalLetters
{
    public static class Calculations
    {
        public static decimal? TotalPremium { get; set; }
       
        public static decimal CreditCharge(decimal? annualPremium)
        {
            decimal? cc = annualPremium * 0.05M;
            decimal creditChrg = 0;

            if (cc is null)
            { }
            else
                creditChrg = cc.Value;

            return creditChrg;
        }

        public static decimal AnnPremiumAndCC(decimal? annualPremium)
        {
            decimal? cc = annualPremium * 1.05M;
            decimal creditChrg = 0;

            if (cc is null)
            { }
            else
            {
                creditChrg = cc.Value;
                TotalPremium = Math.Round(cc.Value, 2);
            }

            return creditChrg;
        }

        public static Tuple<decimal, decimal> MonthlyPayments(decimal? annualPremium)
        {
            decimal? avgMthPay;
            decimal initialMthPay;
            decimal otherMthPay;
            Tuple<decimal, decimal> tuple;

            /* update TotalPremium for new customer */
            AnnPremiumAndCC(annualPremium);

            /* Calculate the average payments per month based on TotalPremium / 12 
             * Round initial payment to 2 decimal places.  
             */

            avgMthPay = TotalPremium / 12M;
            initialMthPay = Math.Round(avgMthPay.Value, 2);
            otherMthPay = (TotalPremium.Value - avgMthPay.Value) / 11M;

            /* 
             * continue incrementing the initial monthly payment by 1 pence until the value given when 
             * subtracted from our Total premium and divided by 11 leaves a value with x2 decimal places
             */

            while ((otherMthPay.ToString().Length - (otherMthPay.ToString().IndexOf('.') + 1)) != 2)
            {
                initialMthPay += 0.01M;
                otherMthPay = (TotalPremium.Value - initialMthPay) / 11;
            }

            tuple = new Tuple<decimal, decimal>(initialMthPay, otherMthPay);
            return tuple;

        }
    }
}
