namespace RateCalculator.Core
{
    using System;

    /// <summary>
    /// Defines the response contract.
    /// </summary>
    public interface ILoanResponse
    {
        /// <summary>
        /// Defines a monthly repayment value.
        /// </summary>
        double MounthlyRepayment { get; set; }

        /// <summary>
        /// Defines an annual payment rate value.
        /// </summary>
        double Rate { get; set; }

        /// <summary>
        /// Defines a requested amount value.
        /// </summary>
        double RequestedAmount { get; set; }

        /// <summary>
        /// Defines a total repayment amount value.
        /// </summary>
        double TotalRepayment { get; set; }
    }
}
