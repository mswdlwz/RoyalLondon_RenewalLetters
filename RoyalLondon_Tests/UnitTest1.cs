using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoyalLondon_RenewalLetters;

namespace RoyalLondon_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private string expected = "£1.10";
        private string expected2 = "£52.50";
        private decimal firstMthPay = 4.43M;
        private decimal otherMthPay = 4.37M;

        [TestMethod]
        public void TestCorrectCredit()
        {
            var result = Calculations.CreditCharge(22m);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TotalPremium()
        {
            var result = Calculations.AnnPremiumAndCC(50m);
            Assert.AreEqual(expected2, result);
        }

        [TestMethod]
        public void MonthlyPaymentFirst()
        {
            var result = Calculations.MonthlyPayments(50m);
            Assert.AreEqual(firstMthPay, result.Item1, "Correct First Payment calculated");
        }

        [TestMethod]
        public void MonthlyPaymentOther()
        {
            var result = Calculations.MonthlyPayments(50m);
            Assert.AreEqual(otherMthPay, result.Item2, "Correct First Payment calculated");
        }

    }
}
