using System;

namespace RoyalLondon_RenewalLetters
{
    public static class Calculations
    {
        public static decimal CreditCharge(decimal annualPremium)
        {
            return (Math.Round(annualPremium * 0.05M, 2));
        }

        public static decimal TotalPremium(decimal annualPremium)
        {
            return (Math.Round(annualPremium * 1.05M, 2));
        }

        public static Tuple<decimal, decimal> MonthlyPayments(decimal annualPremium, decimal totalPremium)
        {
            decimal avgMthPay;
            decimal initialMthPay;
            decimal otherMthPay;
            Tuple<decimal, decimal> tuple;

            /* Calculate the average payments per month based on TotalPremium / 12 
             * Round initial payment to 2 decimal places.  
             */

            //avgMthPay = TotalPremium / 12M;
            avgMthPay = (totalPremium / 12M);
            initialMthPay = Math.Round(avgMthPay, 2);
            otherMthPay = (totalPremium - avgMthPay) / 11M;

            while ((otherMthPay.ToString().Length - (otherMthPay.ToString().IndexOf('.') + 1)) != 2)
            {
                initialMthPay += 0.01M;
                otherMthPay = (totalPremium - initialMthPay) / 11;
            }

            tuple = new Tuple<decimal, decimal>(initialMthPay, otherMthPay);
            return tuple;

        }
    }
}
