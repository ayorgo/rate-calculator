namespace RateCalculator.Core
{
    using System;

    /// <summary>
    /// Defines an available offer item.
    /// </summary>
    public class Offer
    {
        /// <summary>
        /// Gets or sets the available rate.
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// Gets or sets the available amount.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Overrides default comparer.
        /// </summary>
        /// <param name="offer1">First offer to compare.</param>
        /// <param name="offer2">Second offer to compare.</param>
        /// <returns>0 if both offers are equal,
        /// 1 if offer1 is greater than offer2,
        /// -1 if offer1 is less than offer2
        /// </returns>
        public static int CopmareByRate(Offer offer1, Offer offer2)
        {
            if (offer1 == null || offer2 == null)
            {
                throw new ArgumentNullException("An offer cannot be null. Please check the file contents");
            }
            if (offer1.Rate > offer2.Rate)
            {
                return 1;
            }
            if (offer1.Rate < offer2.Rate)
            {
                return -1;
            }
            return 0;
        }
    }
}
