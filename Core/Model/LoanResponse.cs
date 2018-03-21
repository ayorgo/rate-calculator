namespace RateCalculator.Core
{
    /// <summary>
    /// Implements the response contract.
    /// </summary>
    public class LoanResponse : ILoanResponse
    {
        /// <inheritdoc />
        public double RequestedAmount { get; set; }

        /// <inheritdoc />
        public double Rate { get; set; }

        /// <inheritdoc />
        public double MounthlyRepayment { get; set; }

        /// <inheritdoc />
        public double TotalRepayment { get; set; }
    }
}
