using RateCalcServices;
using System;
using System.IO;
using System.Linq;

namespace RateCalcSystem
{
    class Program
    {
        private static string _fileName;
        private static decimal _requestedAmount;

        static void Main(string[] args)
        {
            if (!InitialiseArgs(args))
            {
                UsageInfo();
                return;
            }
            
            var fileName = Path.Combine(Environment.CurrentDirectory, _fileName);
            var service = new LoanOfferService(fileName);
            var loanCalculator = new LoanCalculator(service);

            Loan loan;
            try
            {
                loan = loanCalculator.GetLoanByAverageRate(_requestedAmount);
            }
            catch (NotEnoughLoanOffersException)
            {
                Console.WriteLine("Unfortunately we are not able to offer you a quote at this time as there are no enough lenders available.");
                return;
            }
            
            Console.WriteLine("Requested Amount: £{0}", _requestedAmount);
            Console.WriteLine("Rate: {0}%", loan.AnnualRatePercentage);
            Console.WriteLine("Monthly repayment: £{0}", Math.Round(loan.PeriodRepaymentAmount, 2));
            Console.WriteLine("Total repayment: £{0}", Math.Round(loan.TotalRepaymentAmount,2));
        }

        private static bool InitialiseArgs(string[] args)
        {
            if (args.Length != 2 || args.ToList().Any(p => p == "-?"))
                return false;

            _fileName = args[0];
            if (!decimal.TryParse(args[1], out var result))
            {
                Console.WriteLine("The amount parameter has to be a valid decimal number");
                return false;
            }

            _requestedAmount = result;
            return true;
        }

        private static void UsageInfo()
        {
            Console.WriteLine("ratecalcsystem.exe inputfile.csv amount");
            Console.WriteLine("\n\nParameters:");
            Console.WriteLine("inputfile.csv - an input data file");
            Console.WriteLine("amount - Load amount requested; a number in the range 1000-15000 in increments of 100");
            Console.WriteLine("-?\t\tThis help information.");
        }
    }
}