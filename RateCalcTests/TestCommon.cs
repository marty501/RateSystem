using System.Collections.Generic;
using RateCalcServices;

namespace RateCalcTests
{
    public static class TestCommon
    {
        public static LoanOfferService GetLoanOfferService()
        {
            var offer0 = new LoanOffer("Maria", 0.08M, 400);
            var offer1 = new LoanOffer("George", 0.065M, 1000);
            var offers = new List<LoanOffer> { offer0, offer1 };

            // In reality: it would be an interface (e.g. ILoanOfferService) so that it can be mocked
            var service = new LoanOfferService(offers);
            return service;
        }

        public static LoanOfferService GetLoanOfferServiceExampleData()
        {
            var offers = new List<LoanOffer>
            {
                new LoanOffer("Bob", 0.075M, 640),
                new LoanOffer("Jane", 0.069M, 480),
                new LoanOffer("Fred", 0.071M, 520),
                new LoanOffer("Mary", 0.104M, 170),
                new LoanOffer("John", 0.081M, 320),
                new LoanOffer("Dave", 0.074M, 140),
                new LoanOffer("Angela", 0.071M, 60)
            };

            return new LoanOfferService(offers);
        }
    }
}