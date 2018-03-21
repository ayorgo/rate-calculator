namespace RateCalculator.CoreTest
{
    using RateCalculator.Core;

    public class ConfigurationProviderMock : IConfigurationProvider
    {
        public double AmountMin { get { return 1000.0; } }
        public double AmountMax { get { return 15000.0; } }
        public double Increment { get { return 100.0; } }
        public int CompoundsAYear { get { return 12; } }
        public int TermInYears { get { return 3; } }
    }
}
