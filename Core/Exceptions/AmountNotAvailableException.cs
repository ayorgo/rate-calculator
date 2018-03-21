namespace RateCalculator.Core
{
    using System;

    /// <summary>
    /// New specific exception.
    /// </summary>
    public class AmountNotAvailableException : ArgumentException
    {
        /// <summary>
        /// Constructor taking just a message and passing it to parent.
        /// </summary>
        /// <param name="message"></param>
        public AmountNotAvailableException(string message)
            : base(message) 
        {
        }
    }
}
