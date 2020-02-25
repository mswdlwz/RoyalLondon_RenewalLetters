using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoyalLondon_RenewalLetters;

namespace RoyalLondon_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private decimal expected = 1.10M;
        private decimal expected2 = 52.50M;
        private decimal firstMthPay = 12.41M;
        private decimal otherMthPay = 10.80M;
        private int expectedID = 3;
        private decimal expectedPayAmntTest = 1.23M;
        private decimal expectedAnnPremTest = 0;

        [TestMethod()]
        public void TestValidPaymentAmntTest()
        {
            var result = ValidData.CheckPaymentAmnt("1.23");
            Assert.AreEqual(expectedPayAmntTest, result);
        }

        [TestMethod()]
        public void TestValidAnnualPrem()
        {
            var result = ValidData.CheckAnnualPrem("onetwothree");
            Assert.AreEqual(expectedAnnPremTest, result);
        }
        [TestMethod]
        public void TestValidID()
        {
            var result = ValidData.ChkCustID("3");
            Assert.AreEqual(expectedID, result);
        }

        [TestMethod]
        public void TestCorrectCredit()
        {
            var result = Calculations.CreditCharge(22m);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidTotalPremium()
        {
            var result = Calculations.TotalPremium(50m);
            Assert.AreEqual(expected2, result);
        }

        [TestMethod]
        public void TestMonthlyPaymentFirst()
        {
            var result = Calculations.MonthlyPayments(141.20M, 148.26M);
            Assert.AreEqual(firstMthPay, result.Item1, "Incorrect first Payment calculated");
        }

        [TestMethod]
        public void TestElevenMonthlyPayment()
        {
            var result = Calculations.MonthlyPayments(123.45m, 129.62M);
            Assert.AreEqual(otherMthPay, result.Item2, "Incorrect monthly Payment calculated");
        }

    }
}
