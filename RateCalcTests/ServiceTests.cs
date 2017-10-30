using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RateCalcTests
{
    [TestClass]
    public class ServiceTests
    {

        [TestMethod]
        public void TestNotEnoughOffers()
        {
            var service = TestCommon.GetLoanOfferService();
            var bestOffers = service.GetBestOffers(400 + 1000 + 1);

            Assert.AreEqual(0, bestOffers.Count);
        }

        [TestMethod]
        public void TestEnoughOffers()
        {
            var service = TestCommon.GetLoanOfferService();
            var bestOffers = service.GetBestOffers(400 + 1000);

            Assert.AreEqual(2, bestOffers.Count);
        }
    }
}