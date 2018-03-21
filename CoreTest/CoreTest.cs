namespace RateCalculator.CoreTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using RateCalculator.Core;

    [TestClass]
    public class CoreTest
    {
        public LoanRequestMock loanRequestMock = new LoanRequestMock();
        public Engine engine = new Engine(new ConfigurationProviderMock());
        public Controller controller = new Controller(new ConfigurationProviderMock());

        [TestMethod]
        public void Engine_CalculateAnnualRate_Value()
        {
            double annualRate = engine.GetAnnualRate(loanRequestMock.Offers, loanRequestMock.LoanAmount);
            Assert.AreEqual(0.07, annualRate, 0.001);
        }

        [TestMethod]
        public void Engine_CalculateMonthlyRepayment_Value()
        {
            double monthlyRepayment = engine.GetMonthlyRepayment(loanRequestMock.Offers, 1233.08);
            Assert.AreEqual(34.25, monthlyRepayment, 0.01);
        }

        [TestMethod]
        public void Engine_CalculateTotalRepayment_Value()
        {
            double totalRepayment = engine.GetTotalRepayment(loanRequestMock.Offers);
            Assert.AreEqual(1233.08, totalRepayment, 0.01);
        }

        [TestMethod]
        public void Engine_CalculateRepayment_Value()
        {
            double repayment = engine.GetSpecificRepayment(loanRequestMock.Offers.First());
            Assert.AreEqual(643.04, repayment, 0.01);
        }

        [TestMethod]
        [ExpectedException(typeof(AmountNotAvailableException))]
        public void Controller_ValidateRequest_ThrowNotAvailable()
        {
            ILoanRequest loanRequest = new LoanRequestMock();
            loanRequest.LoanAmount = 10100.0;
            controller.ValidateRequest(loanRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Controller_ValidateRequest_ThrowOutOfRangeLess()
        {
            ILoanRequest loanRequest = new LoanRequestMock();
            loanRequest.LoanAmount = 900.0;
            controller.ValidateRequest(loanRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Controller_ValidateRequest_ThrowOutOfRangeMore()
        {
            ILoanRequest loanRequest = new LoanRequestMock();
            loanRequest.LoanAmount = 16000.0;
            controller.ValidateRequest(loanRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Controller_ValidateRequest_ThrowIncrement()
        {
            ILoanRequest loanRequest = new LoanRequestMock();
            loanRequest.LoanAmount = 1350.0;
            controller.ValidateRequest(loanRequest);
        }
    }
}
