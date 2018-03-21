namespace RateCalculator.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implements the core logic of the module.
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// Configuration provider reference.
        /// </summary>
        public IConfigurationProvider configProvider;

        /// <summary>
        /// Constructor initializing default configuration provider.
        /// </summary>
        public Engine()
        {
            configProvider = new ConfigurationProvider();
        }

        /// <summary>
        /// Constructor taking a configuration provider implementation as an argument.
        /// </summary>
        /// <param name="provider">Configuration provider implementation</param>
        public Engine(IConfigurationProvider provider)
        {
            configProvider = provider;
        }

        /// <summary>
        /// Selects the best available offers.
        /// </summary>
        /// <param name="offers">Available offers.</param>
        /// <param name="amount">Requested amount.</param>
        /// <returns>Optimized offers list.</returns>
        public List<Offer> SelectOffers(List<Offer> offers, double amount)
        {
            offers.Sort(Offer.CopmareByRate);
            List<Offer> result = new List<Offer>();
            foreach (Offer offer in offers)
            {
                amount -= offer.Amount;
                if (amount <= 0)
                {
                    offer.Amount += amount;
                    result.Add(offer);
                    break;
                }
                result.Add(offer);
            }
            return result;
        }

        /// <summary>
        /// Calculates annual interest rate.
        /// </summary>
        /// <param name="offers">Available offers.</param>
        /// <param name="amount">Requested amount.</param>
        /// <returns>Annual interest rate.</returns>
        public double GetAnnualRate(List<Offer> offers, double amount)
        {
            return offers.Sum(o => o.Amount * o.Rate) / amount;
        }

        /// <summary>
        /// Calculates monthly repayment value.
        /// </summary>
        /// <param name="offers">Available offers.</param>
        /// <param name="totalRepayment">Total repayment.</param>
        /// <returns>Monthly repayment value.</returns>
        public double GetMonthlyRepayment(List<Offer> offers, double totalRepayment)
        {
            return totalRepayment / (configProvider.CompoundsAYear * configProvider.TermInYears); ;
        }

        /// <summary>
        /// Calculates total repayment on the requested loan.
        /// </summary>
        /// <param name="offers">Available offers.</param>
        /// <returns>Total repayment value.</returns>
        public double GetTotalRepayment(List<Offer> offers)
        {
            return offers.Sum(o => GetSpecificRepayment(o));
        }

        /// <summary>
        /// Calculates repayment value per lender.
        /// </summary>
        /// <param name="offer">Specific offer.</param>
        /// <returns>Repayment value.</returns>
        public double GetSpecificRepayment(Offer offer)
        {
            return offer.Amount * Math.Pow(1 + (offer.Rate / configProvider.CompoundsAYear),
                configProvider.CompoundsAYear * configProvider.TermInYears);
        }
    }
}
