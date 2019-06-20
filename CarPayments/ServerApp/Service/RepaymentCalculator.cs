using CarPayments.ServerApp.Domain.Model;
using CarPayments.ServerApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPayments.ServerApp.Service
{
    public class RepaymentCalculator : IRepaymentCalculator
    {

        public List<RepaymentsModel> CalculateRepaymentValues(PaymentsModel payments,ChargesModel charges)
        {
            var monthsInYear = 12;
            var repaymentList = new List<RepaymentsModel>();
            var numberOfPaymonths = payments.YearsOfAgreement * monthsInYear;
            var repaymentPerMonth = decimal.Round((payments.BorrowAmount - payments.DepositAmount) / numberOfPaymonths, 2);
            var payMonth = payments.DeliveryDate.AddMonths(1);



            for (int i = 0; i < numberOfPaymonths; i++)
            {
                DateTime startDatePayMonth = new DateTime(payMonth.Year, payMonth.Month, 1);

                while (startDatePayMonth.DayOfWeek.ToString() != "Monday")
                {
                    startDatePayMonth = startDatePayMonth.AddDays(1);
                }
                repaymentList.Add(new RepaymentsModel { RepaymentDate = startDatePayMonth, RepaymentAmount = repaymentPerMonth });

                payMonth = payMonth.AddMonths(1);
            }

            repaymentList.First().RepaymentAmount = repaymentList.First().RepaymentAmount + charges.ArrangementFee;
            repaymentList.Last().RepaymentAmount = repaymentList.Last().RepaymentAmount + charges.CompletionFee;
            return repaymentList;
        }

    }
}
