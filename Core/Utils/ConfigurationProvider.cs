namespace RateCalculator.Core
{
    using System.Configuration;

    /// <summary>
    /// Implements the configuration values provider.
    /// </summary>
    public class ConfigurationProvider : IConfigurationProvider
    {
        /// <inheritdoc />
        public double AmountMin { get { return double.Parse(ConfigurationManager.AppSettings["MinimumAmount"]); } }

        /// <inheritdoc />
        public double AmountMax { get { return double.Parse(ConfigurationManager.AppSettings["MaximumAmount"]); } }

        /// <inheritdoc />
        public double Increment { get { return double.Parse(ConfigurationManager.AppSettings["Increment"]); } }

        /// <inheritdoc />
        public int CompoundsAYear { get { return int.Parse(ConfigurationManager.AppSettings["CompoundsAYear"]); } }

        /// <inheritdoc />
        public int TermInYears { get { return int.Parse(ConfigurationManager.AppSettings["TermInYears"]); } }
    }
}
