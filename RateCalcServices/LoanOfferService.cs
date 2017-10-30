using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RateCalcServices
{
    /// <summary>
    /// Obtains loan offers from a service (here: file)
    /// </summary>
    public class LoanOfferService
    {
        private readonly string _fileName;
        private readonly List<LoanOffer> _sortedLoanOffers;

        public LoanOfferService(string fileName)
        {
            _fileName = fileName;
            _sortedLoanOffers = GetLoanOffers().OrderBy(p => p.Rate).ToList();
        }

        public LoanOfferService(List<LoanOffer> offers)
        {
            _sortedLoanOffers = offers.OrderBy(p => p.Rate).ToList();
        }

        private List<LoanOffer> GetLoanOffers()
        {
            var loanOffers = new List<LoanOffer>();
            using (var reader = new StreamReader(_fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var columns = line.Split(',');
                    if (!decimal.TryParse(columns[1], out _) && !decimal.TryParse(columns[2], out _))
                        continue;

                    var loanOffer = new LoanOffer(columns[0], Convert.ToDecimal(columns[1]), Convert.ToDecimal(columns[2]));
                    loanOffers.Add(loanOffer);
                }
            }
            return loanOffers;
        }

        /// <summary>
        /// Returns 1 or more offers than satisfy the requested Amount. Return empty list of none;
        /// </summary>
        /// <param name="requestedAmount"></param>
        /// <returns></returns>
        public List<LoanOffer> GetBestOffers(decimal requestedAmount)
        {
            if (_sortedLoanOffers.Count < 1)
                throw new Exception("No offers were obtained from the service.");

            var offersResult = new List<LoanOffer>();
            decimal amount = 0M;
            for (var i = 0; i < _sortedLoanOffers.Count; i++)
            {
                var offer = _sortedLoanOffers[i];
                amount += offer.Available;
                offersResult.Add(offer);

                if (amount >= requestedAmount)
                    return offersResult;
            }

            if (amount < requestedAmount)
            {
                offersResult.Clear();
            }

            return offersResult;
        }
    }
}