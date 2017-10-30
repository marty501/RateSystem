using System;

namespace RateCalcServices
{
    public class Loan
    {
        private const int LOWER_LIMIT = 1000;
        private const int UPPER_LIMIT = 15000;
        private const int LIMIT_STEP = 100;

        private readonly decimal _annualRate;
        private readonly decimal _annualRatePercentage;
        private readonly decimal _presentValue;
        private decimal _periodRepaymentAmount;
        private decimal _totalRepaymentAmount;

        public decimal PeriodEffectiveRate { get; set; }

        public decimal PeriodRepaymentAmount
        {
            get => Math.Round(_periodRepaymentAmount, 2);
            set => _periodRepaymentAmount = value;
        }

        public decimal TotalRepaymentAmount
        {
            get => Math.Round(_totalRepaymentAmount, 2);
            set => _totalRepaymentAmount = value;
        }

        public decimal AnnualRate => _annualRate;

        public decimal AnnualRatePercentage => _annualRatePercentage;
        public decimal PresentValue => _presentValue;


        public Loan(decimal annualRate, decimal presentValue)
        {
            if (annualRate <= 0)
                throw new Exception("The annual rate cannot be negative or zero");

            if (presentValue < LOWER_LIMIT || presentValue > UPPER_LIMIT)
                throw new Exception($"Loan amount can be from {LOWER_LIMIT} to {UPPER_LIMIT}.");

            if (presentValue % LIMIT_STEP != 0)
                throw new Exception(
                    $"The amount requested is not within the range {LOWER_LIMIT} - {UPPER_LIMIT} with an increment of {LIMIT_STEP}.");

            _annualRate = annualRate;
            _annualRatePercentage = Math.Round(annualRate * 100, 1);
            _presentValue = presentValue;
        }
    }
}