namespace RateCalculator.Main
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Globalization;
    using System.IO;
    using RateCalculator.Core;

    class Program
    {
        static void Main(string[] args)
        {
            LoanRequest loanRequest = new LoanRequest
            {
                LoanAmount = double.Parse(args[1]),
                Offers = ReadFile(args[0])
            };
            LoanResponse loanResponse = null;
            Controller controller = new Controller();
            try
            {
                controller.ValidateRequest(loanRequest);
                loanResponse = controller.Calculate(loanRequest) as LoanResponse;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            if (loanResponse != null)
            {
                CultureInfo culture = new CultureInfo(ConfigurationManager.AppSettings["DefaultCulture"]);
                Console.WriteLine("Requested amount: " + loanResponse.RequestedAmount.ToString("C", culture));
                Console.WriteLine("Rate: " + loanResponse.Rate.ToString("P1"));
                Console.WriteLine("Monthly repayment: " + loanResponse.MounthlyRepayment.ToString("C2", culture));
                Console.WriteLine("Total repayment: " + loanResponse.TotalRepayment.ToString("C2", culture));
            }
        }

        static List<Offer> ReadFile(string fileName)
        {
            List<Offer> result = new List<Offer>();
            StreamReader reader = new StreamReader(fileName);
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');
                result.Add(new Offer
                {
                    Rate = double.Parse(values[1]),
                    Amount = double.Parse(values[2])
                });
            }
            return result;
        }
    }
}
