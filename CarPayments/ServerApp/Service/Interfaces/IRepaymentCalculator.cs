using CarPayments.ServerApp.Domain.Model;
using System.Collections.Generic;

namespace CarPayments.ServerApp.Service.Interfaces
{
    public interface IRepaymentCalculator
    {
        List<RepaymentsModel> CalculateRepaymentValues(PaymentsModel payments, ChargesModel charges);
    }
}