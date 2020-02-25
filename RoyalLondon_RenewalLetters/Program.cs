/* Author: Martin Wright
 * Date: 25/02/2020
 * Version: 2
 * Revisions:
 *          Moved checks for valid ID, payout amount and annual premium into a 
 *          seperate "ValidData" class and methods.
 *          Further class added to hold Insurance Product details (name, payout ammount, annual premium)
 *          CustLetter class added to handle creation of letters
 *          Calculation methods revised with "Calculations" Class
 *          Additional Unit tests added for new methods within "ValidData" Class
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

                            Customer customer = new Customer(ValidData.ChkCustID(customerDetl[0]), customerDetl[1], customerDetl[2], customerDetl[3]);

                            Product product = new Product(customerDetl[4], ValidData.CheckPaymentAmnt(customerDetl[5]), ValidData.CheckAnnualPrem(customerDetl[6]));

                            /* Check if letter exists, and if not, create */
                            if (!File.Exists(@$"C:\RoyalLondon\Out\{customer.ID}_{customer.Firstname}{customer.Surname}.txt"))
                                CustLetter.CreateLetter(customer, product);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                EventLog.WriteEntry("RoyalLondon_RenewalLetters", err.Message);
            }
        }
    }
}
