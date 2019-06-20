using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPayments.ServerApp.Domain.Model
{
    public class PaymentsModel
    {
        public decimal BorrowAmount { get; set; }
        public decimal DepositAmount { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int YearsOfAgreement { get; set; }
    }
}
