using RateCalcServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalcSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            // open and read the file

            // sort the result by asc rate

            decimal rate = 0M;
            decimal requestedAmount = 1000M;


            var loan = new Loan(rate, requestedAmount);

            var loanCalculator = new LoanCalculator();
            loan = loanCalculator.CalculateLoan(loan);

            Console.WriteLine("Requested Amount: £{0}", requestedAmount);
            Console.WriteLine("Rate: {0}%", rate * 100);
            Console.WriteLine("Monthly repayment: £{0}", Math.Round(loan.PeriodRepaymentAmount, 2));
            Console.WriteLine("Total repayment: £{0}", Math.Round(loan.TotalRepaymentAmount,2));

            Console.ReadLine();
        }
    }
}
