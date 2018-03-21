namespace RateCalculator.Core
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the request contract.
    /// </summary>
    public interface ILoanRequest
    {
        /// <summary>
        /// Defines a requested amount value.
        /// </summary>
        double LoanAmount { get; set; }

        /// <summary>
        /// Defines a collection of available offers.
        /// </summary>
        List<Offer> Offers { get; set; }
    }
}
