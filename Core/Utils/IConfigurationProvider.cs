namespace RateCalculator.Core
{
    /// <summary>
    /// Defines the configuration values provider.
    /// </summary>
    public interface IConfigurationProvider
    {
        /// <summary>
        /// Defines the mininum amount that can be requested.
        /// </summary>
        double AmountMin { get; }

        /// <summary>
        /// Defines the maximum amount that can be requested.
        /// </summary>
        double AmountMax { get; }

        /// <summary>
        /// Defines the amount granularity value. 
        /// </summary>
        double Increment { get; }

        /// <summary>
        /// Defines the number of times the interest is compounded per year.
        /// </summary>
        int CompoundsAYear { get; }

        /// <summary>
        /// Defines the number of years the money is borrowed for.
        /// </summary>
        int TermInYears { get; }
    }
}
