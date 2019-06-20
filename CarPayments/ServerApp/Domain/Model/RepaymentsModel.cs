using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPayments.ServerApp.Domain.Model
{
    public class RepaymentsModel
    {
        public DateTime RepaymentDate { get; set; }
        public decimal RepaymentAmount { get; set; }
    }
}
