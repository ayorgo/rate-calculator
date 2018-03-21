namespace RateCalculator.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Imlements a functional interface to a view (console app).
    /// </summary>
    public class Controller
    {
        /// <summary>
        /// Configuration provider reference.
        /// </summary>
        public IConfigurationProvider configProvider;

        /// <summary>
        /// Constructor initializing default configuration provider.
        /// </summary>
        public Controller()
        {
            configProvider = new ConfigurationProvider();
        }

        /// <summary>
        /// Constructor taking a configuration provider implementation as an argument.
        /// </summary>
        /// <param name="provider">Configuration provider implementation</param>
        public Controller(IConfigurationProvider provider)
        {
            configProvider = provider;
        }

        /// <summary>
        /// Validates a given request according to existing rules and limitations.
        /// </summary>
        /// <param name="request">Loan request object</param>
        public void ValidateRequest(ILoanRequest request)
        {
            if (request.LoanAmount < configProvider.AmountMin || request.LoanAmount > configProvider.AmountMax)
            {
                throw new ArgumentOutOfRangeException("Amount");
            }

            if (request.LoanAmount % 100 != 0)
            {
                throw new ArgumentException("The requested amount should be divisible by 100");
            }

            if (request.Offers.Sum(o => o.Amount) < request.LoanAmount)
            {
                throw new AmountNotAvailableException("The requested amount is not available");
            }
        }

        /// <summary>
        /// Calculates the response.
        /// </summary>
        /// <param name="request">Loan request object</param>
        /// <returns>Loan response object</returns>
        public ILoanResponse Calculate(ILoanRequest request)
        {
            Engine engine = new Engine();
            List<Offer> workingOffers = engine.SelectOffers(request.Offers, request.LoanAmount);

            LoanResponse response = new LoanResponse();
            response.RequestedAmount = request.LoanAmount;
            response.Rate = engine.GetAnnualRate(workingOffers, request.LoanAmount);
            response.TotalRepayment = engine.GetTotalRepayment(workingOffers);
            response.MounthlyRepayment = engine.GetMonthlyRepayment(workingOffers, response.TotalRepayment);
            return response;
        }
    }
}
