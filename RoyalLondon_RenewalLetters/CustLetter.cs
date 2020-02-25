using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RoyalLondon_RenewalLetters
{
    public static class CustLetter
    {
        public static void CreateLetter(Customer customer, Product product)
        {
            if (customer.ID != 0 && product.AnnualPremium != 0 && product.PayoutAmount != 0)
            {
                Tuple<decimal, decimal> mthlPay = Calculations.MonthlyPayments(product.AnnualPremium, Calculations.TotalPremium(product.AnnualPremium));

                using (StreamWriter writer = new StreamWriter($@"C:\RoyalLondon\Out\{customer.ID}_{customer.Firstname}{customer.Surname}.txt"))
                {
                    writer.WriteLine(DateTime.Now.ToShortDateString());
                    writer.WriteLine();
                    writer.WriteLine($"FAO: {customer.Title} {customer.Firstname} {customer.Surname} ");
                    writer.WriteLine();
                    writer.WriteLine("RE: Your Renewal");
                    writer.WriteLine();
                    writer.WriteLine($"Dear {customer.Title} {customer.Surname}");
                    writer.WriteLine();
                    writer.WriteLine("We hereby invite you to renew your Insurance Policy, subject to the following terms.");
                    writer.WriteLine();
                    writer.WriteLine($"Your chosen insurance product is {product.ProductName}.");
                    writer.WriteLine();
                    writer.WriteLine($"The amount payable to you in the event of a valid claim will be {product.PayoutAmount:C2}.");
                    writer.WriteLine();
                    writer.WriteLine($"Your annual premium will be {product.AnnualPremium:C2}.");
                    writer.WriteLine();
                    writer.WriteLine($"If you choose to pay by Direct Debit, we will add a credit charge of {Calculations.CreditCharge(product.AnnualPremium):C2}, " +
                                    "bringing the total to " + $"{Calculations.TotalPremium(product.AnnualPremium):C2}.\n" +
                                    $"This is payable by an initial payment of {mthlPay.Item1:C2},  followed by 11 payments of {mthlPay.Item2:C2} each.");
                    writer.WriteLine();
                    writer.WriteLine("Please get in touch with us to arrange your renewal by visiting https://www.regallutoncodingtest.co.uk/renew" +
                                     "\nor calling us on 01625 123456.");
                    writer.WriteLine();
                    writer.WriteLine("Kind regards");
                    writer.WriteLine("Regal Luton");
                    writer.Flush();

                }
            }
        }
    }
}
