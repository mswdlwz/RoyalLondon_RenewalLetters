/* Author: Martin Wright
 * Date: 20/02/2020
 * Version: 1
 * Revisions:
 */

using System;
using System.IO;
using System.Diagnostics;

namespace RoyalLondon_RenewalLetters
{
    class Program : Exception
    {
        static string[] customerDetl;
        static void Main(string[] args)
        {
            try
            {
                if (File.Exists(@"C:\RoyalLondon\In\Customer.csv"))
                {
                    using (StreamReader reader = new StreamReader(@"C:\RoyalLondon\In\Customer.csv"))
                    {
                        reader.ReadLine(); // Read past header.
                        while (!reader.EndOfStream)
                        {

                            customerDetl = reader.ReadLine().Split(',');
                            /* Create our customer */
                            Customer.GetCustomer(customerDetl);

                            /* Check if Customer ID, payout and annual premium are not null. These will be set to null
                             * if the values in the input file could not be parsed as int, or decimal values
                             */

                            if (Customer.ID is null )
                            {
                                throw new InvalidDataException(@"[Invalid Customer ID recorded to input file]");                                
                            }
                            else if (Customer.PayoutAmount is null)
                            {
                                throw new InvalidDataException(@"[Invalid PayoutAmount recorded to input file]");
                            }
                            else if( Customer.AnnualPremium is null )
                            {
                                throw new InvalidDataException(@"[Invalid AnnualPremium recorded to input file]");
                            }
                            else
                            {
                                /* Check if letter exists, and if not, create */
                                if (!File.Exists(@$"C:\RoyalLondon\Out\{Customer.ID}_{Customer.Firstname}{Customer.Surname}.txt"))
                                {
                                    // Calculate are initial monthly payment, along with the remaining 11
                                    Tuple<decimal, decimal> mthlyPay = Calculations.MonthlyPayments(Customer.AnnualPremium);

                                    using (StreamWriter writer = new StreamWriter($@"C:\RoyalLondon\Out\{Customer.ID}_{Customer.Firstname}{Customer.Surname}.txt"))
                                    {
                                        writer.WriteLine(DateTime.Now.ToShortDateString());
                                        writer.WriteLine();
                                        writer.WriteLine($"FAO: {Customer.Title} {Customer.Firstname} {Customer.Surname} ");
                                        writer.WriteLine();
                                        writer.WriteLine("RE: Your Renewal");
                                        writer.WriteLine();
                                        writer.WriteLine($"Dear {Customer.Title} {Customer.Surname}");
                                        writer.WriteLine();
                                        writer.WriteLine("We hereby invite you to renew your Insurance Policy, subject to the following terms.");
                                        writer.WriteLine();
                                        writer.WriteLine($"Your chosen insurance product is {Customer.ProductName}.");
                                        writer.WriteLine();
                                        writer.WriteLine($"The amount payable to you in the event of a valid claim will be {Customer.PayoutAmount:C2}.");
                                        writer.WriteLine();
                                        writer.WriteLine($"Your annual premium will be {Customer.AnnualPremium:C2}.");
                                        writer.WriteLine();
                                        writer.WriteLine("If you choose to pay by Direct Debit, we will add a credit charge of " + string.Format($"{Calculations.CreditCharge(Customer.AnnualPremium):C2}") + ", " +
                                                        "bringing the total to " + $"{Calculations.TotalPremium:C2}.\n" + "This is payable by an initial payment of " +
                                                        "" + string.Format($"{mthlyPay.Item1:C2}") + ", followed by 11 payments of " + string.Format($"{mthlyPay.Item2:C2}") + " each. ");
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
                }
            }
            catch (InvalidDataException err)
            {
                EventLog.WriteEntry("RoyalLondon_RenewalLetters", err.Message);
            }
        }
    }
}
