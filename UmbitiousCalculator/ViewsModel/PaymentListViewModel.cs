using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbitiousCalculator.ViewsModel
{
    public class PaymentListViewModel
    {
        public int Id { get; set; }
        public double MonthlyPayment { get; set; }
        public double MonthlyPrincipal { get; set; }
        public double MonthlyInterest { get; set; }
        public double Balance { get; set; }
        public double TotalPrincipal { get; set; }
        public double TotalInterest { get; set; }
    }
}