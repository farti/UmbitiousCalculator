using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Web;
using UmbitiousCalculator.ViewsModel;

namespace UmbitiousCalculator.Models
{
    public class Credit
    {

        [Required(ErrorMessage = "Please enter the amount of credit.")]
        public double AmountOfCredit { get; set; }

        [Required(ErrorMessage = "Please enter the interest rate.")]
        public double InterestRatePerYear { get; set; }

        [Required(ErrorMessage = "Please enter the number of month.")]
        public double TermInMonths { get; set; }

        public Credit(double amountOfCredit, double interestRatePerYear, int termInMonths)
        {
            AmountOfCredit = amountOfCredit;
            InterestRatePerYear = interestRatePerYear;
            TermInMonths = termInMonths;

        }

        // https://pl.wikipedia.org/wiki/Annuita

        private ArrayList Payments(double amountOfCredit, double termInMonths, double interestRatePerYear, double monthlyPayment)
        {
            double monthlyPrincipal = 0;
            double totalPrincipal = 0;
            double totalInterest = 0;
            double monthlyInterest;
            double balance = amountOfCredit;

            ArrayList payments = new ArrayList();

            for (int i = 0; i < termInMonths - 1; i++)
            {

                monthlyInterest = MonthlyInterestAmount(balance, interestRatePerYear);
                monthlyPrincipal = monthlyPayment - monthlyInterest;
                totalPrincipal = totalPrincipal + monthlyPrincipal;
                totalInterest = totalInterest + monthlyInterest;
                balance = balance - monthlyPrincipal;

                payments.Add(new PaymentListViewModel()
                {
                    Id = i + 1,
                    MonthlyPayment = monthlyPayment,
                    MonthlyInterest = monthlyInterest,
                    MonthlyPrincipal = monthlyPrincipal,
                    Balance = balance,
                    TotalPrincipal = totalPrincipal,
                    TotalInterest = totalInterest
                });
            }

            return payments;

        }

        public double MonthlyInterestAmount(double principal, double interest)
        {
            return principal * ((interest / 100) * (1.0 / 12 / 0));
        }

        private static double AmountTotal(double termInMonths, double monthlyPayment)
        {

            return termInMonths * monthlyPayment;
        }


        private static double MonthlyPayment(double amountOfCredit, double interestRatePerYear, double termInMonths)
        {
            try
            {
                double monthlyPayment;
                double interestRate;
                interestRate = (interestRatePerYear / 100) * (1.0 / 12.0);
                monthlyPayment = (amountOfCredit * interestRate * (Math.Pow((1 + interestRate), termInMonths))) / (Math.Pow((1 + interestRate), termInMonths) - 1);
                return monthlyPayment;
            }
            catch
            {
                return 0.0;
            }
        }
    }
}