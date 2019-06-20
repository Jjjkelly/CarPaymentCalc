using System.Collections.Generic;
using CarPayments.ServerApp.Domain.Model;
using CarPayments.ServerApp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarPayments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPaymentController : ControllerBase
    {
        public IRepaymentCalculator _repay;
        public IAdditionalCharges _additionalCharges;
        public CarPaymentController(IRepaymentCalculator repay,IAdditionalCharges additionalCharges)
        {
             _repay = repay;
            _additionalCharges = additionalCharges;
        }

        // POST: api/CarPayment
        [HttpPost]
        public string Post( PaymentsModel value)
        {
            
            ChargesModel Charges = _additionalCharges.Get();
            List<RepaymentsModel> PaymentList = _repay.CalculateRepaymentValues(value,Charges);
            string body = JsonConvert.SerializeObject(PaymentList, Formatting.Indented);

            return  body;
        }
    }
}
