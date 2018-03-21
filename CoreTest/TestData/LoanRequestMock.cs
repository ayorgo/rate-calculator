namespace RateCalculator.CoreTest
{
    using System.Collections.Generic;
    using RateCalculator.Core;

    public class LoanRequestMock : ILoanRequest
    {
        private double loanAmount = 1000.0;
        public double LoanAmount { get { return loanAmount; } set { loanAmount = value; } }
        public List<Offer> Offers
        {
            get
            {
                return new List<Offer>
                {
                    //new Offer { Rate = 0.075, Amount = 640.0 },
                    new Offer { Rate = 0.071, Amount = 520.0 },
                    new Offer { Rate = 0.069, Amount = 480.0 }
                    //new Offer { Rate = 0.104, Amount = 170.0 },
                    //new Offer { Rate = 0.081, Amount = 320.0 },
                    //new Offer { Rate = 0.074, Amount = 140.0 },
                    //new Offer { Rate = 0.071, Amount = 60.0 }
                };
            }
            set { }
        }
    }
}
