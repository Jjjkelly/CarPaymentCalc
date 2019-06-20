using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarPayments.ServerApp.Service;
using CarPayments.ServerApp.Domain.Model;
using Microsoft.Extensions.Configuration;

namespace CarPayments.Test
{
    [TestClass]
    public class ServiceTest
    {
        public AdditionalCharges _charge;
        public RepaymentCalculator _repay;
        public IConfiguration config;
        public ServiceTest()
        {
            _charge = new AdditionalCharges(config);
            _repay = new RepaymentCalculator();
        }
        //Configuration Access Issue to resolve in test.

        //[TestMethod]
        //public void DoesReturnChargesValues()
        //{
        //    var result = _charge.Get();

        //    Assert.IsNotNull(result,$"{result.ArrangementFee} is not null");
        //}

        [TestMethod]
        public void DoesReturnRepaymentValues()
        {
            var model = new PaymentsModel() { BorrowAmount = 1000.00M, DepositAmount = 150.00M, DeliveryDate = new System.DateTime(), YearsOfAgreement = 1 };
            var charges = new ChargesModel(){ ArrangementFee =88,CompletionFee =20};
            var result = _repay.CalculateRepaymentValues(model, charges);

            Assert.IsNotNull(result, $"{result.Count} is not null");
        }
    }
}
