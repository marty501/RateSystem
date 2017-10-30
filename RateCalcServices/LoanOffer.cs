using System;

namespace RateCalcServices
{
    public class LoanOffer
    {
        public string Lender { get; }
        public decimal Rate { get; }
        public decimal Available { get; }

        public LoanOffer(string lender, decimal rate, decimal available)
        {
            Lender = lender;

            if (rate <= 0)
                throw new ArgumentOutOfRangeException(nameof(rate), "Rate cannot be zero or a negative number.");
            Rate = rate;
            if (available <= 0)
                throw new ArgumentOutOfRangeException(nameof(available), "The available amount cannot be zero or a negative number.");
            Available = available;
        }
    }
}