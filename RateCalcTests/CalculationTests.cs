using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RateCalcServices;

namespace RateCalcTests
{
    [TestClass]
    public class CalculationTests
    {
        [TestMethod]
        public void TestCalculationOK()
        {
            var service = TestCommon.GetLoanOfferServiceExampleData();
            var loanCalculator = new LoanCalculator(service);

            var loan = loanCalculator.GetLoanByAverageRate(1000);

            Assert.AreEqual(1000M, loan.PresentValue);
            Assert.AreEqual(7.0M, loan.AnnualRatePercentage);
            Assert.AreEqual(30.78M, loan.PeriodRepaymentAmount);
            Assert.AreEqual(1108.08M, loan.TotalRepaymentAmount); //. 10? 30.78*36 = 1108.08

        }

        [TestMethod]
        [ExpectedException(typeof(Exception),"")]
        public void TestCalculationBadAmount()
        {
            var service = TestCommon.GetLoanOfferServiceExampleData();
            var loanCalculator = new LoanCalculator(service);

            var loan = loanCalculator.GetLoanByAverageRate(1250);
        }
    }
}