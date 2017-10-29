using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalcServices
{
    public class Loan
    {
        private readonly decimal _annualRate;
        private readonly decimal _presentValue;

        public decimal PeriodEffectiveRate { get; set; }

        public decimal PeriodRepaymentAmount { get; set; }

        public decimal TotalRepaymentAmount { get; set; }

        public decimal AnnualRate => _annualRate;
        public decimal PresentValue => _presentValue;


        public Loan(decimal annualRate, decimal presentValue)
        {
            if (annualRate <= 0)
                throw new Exception("The annual rate cannot be negative or zero");

            if (presentValue < 1000 || presentValue > 15000)
                throw new Exception("Loan amount can be from 100 to 15000.");

            _annualRate = annualRate;
            _presentValue = presentValue;
        }
    }
}