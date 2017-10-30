using System;
using System.Linq;

namespace RateCalcServices
{
    /// <summary>
    /// LoanCalculator calculates and returns a 36-months Loan based on available offers
    /// </summary>
    public class LoanCalculator
    {
        private const int PERIOD = 36; // It'd be an input but to limit scope...
        private readonly LoanOfferService _service;

        public LoanCalculator(LoanOfferService service)
        {
            _service = service;
        }
        
        private void CalculateEffectiveRate(Loan loan)
        {
            const double monthlyRate = 12;

            var rate = 1 + (double)loan.AnnualRate;
            var power = Math.Pow(rate, 1 / monthlyRate) - 1;

            loan.PeriodEffectiveRate = (decimal)power;
        }

        private void CalculatePeriodicPaymentAmount(Loan loan)
        {
             loan.PeriodRepaymentAmount = loan.PeriodEffectiveRate * loan.PresentValue / (decimal)(1 - Math.Pow(1 + (double)loan.PeriodEffectiveRate, -PERIOD));
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="requestedAmount"></param>
        /// <returns></returns>
        public Loan GetLoanByAverageRate(decimal requestedAmount)
        {
            var bestOffers = _service.GetBestOffers(requestedAmount);
            if (bestOffers.Count < 1)
                throw new NotEnoughLoanOffersException("No enough lenders available to satisfy requested amount.");

            decimal averageRate = Math.Round((from r in bestOffers select r.Rate).Average(), 2);
            var loan = new Loan(averageRate, requestedAmount);

            CalculateEffectiveRate(loan);
            CalculatePeriodicPaymentAmount(loan);
            loan.TotalRepaymentAmount = loan.PeriodRepaymentAmount * PERIOD;

            return loan;
        }
    }
}