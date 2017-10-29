using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalcServices
{
    public class LoanCalculator
    {
        private const int _period = 36;
       
        private void CalculateEffectiveRate(Loan loan)
        {
            double monthlyRate = 12;

            var rate = 1 + (double)loan.AnnualRate;
            var power = Math.Pow(rate, 1 / monthlyRate) - 1;

            loan.PeriodEffectiveRate = (decimal)power;
        }

        private void CalculatePeriodicPaymentAmount(Loan loan)
        {
             loan.PeriodRepaymentAmount = (loan.PeriodEffectiveRate * loan.PresentValue) /
                             (decimal)(1 - Math.Pow((1 + (double)loan.PeriodEffectiveRate), -_period));

        }

        public Loan CalculateLoan(Loan loan)
        {
            CalculateEffectiveRate(loan);
            CalculatePeriodicPaymentAmount(loan);

            loan.TotalRepaymentAmount = loan.PeriodRepaymentAmount * _period;

            return loan;
        }
    }
}