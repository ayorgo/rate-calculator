namespace RateCalculator.Core
{
    using System.Collections.Generic;

    /// <summary>
    /// Implements the request contract.
    /// </summary>
    public class LoanRequest : ILoanRequest
    {
        /// <inheritdoc />
        public double LoanAmount { get; set; }

        /// <inheritdoc />
        public List<Offer> Offers { get; set; }
    }
}
