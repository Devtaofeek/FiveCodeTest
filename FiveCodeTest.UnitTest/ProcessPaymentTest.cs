using FiveCode.Application.Features.Payment.Command;
using FiveCode.Application.PaymentGateways;
using NUnit.Framework;

namespace FiveCodeTest.UnitTest
{
    [TestFixture]
    public class ProcessPaymentTest
    {
        [Test]
        public void ReturnCheapPaymentGateway_IfAmountIsLessThanTwenty()
        {
            var gateway = new PaymentProcessor();
               
          
            var returnedtype = gateway.GetPayment(15);

            Assert.IsInstanceOf(typeof(CheapPaymentGateway), returnedtype);
        }

        [Test]
        public void ReturnExpensivePaymentGateway_IfAmountIsGreaterThanTwentyOneAndLessThanOrEqualTOFiveHundred()
        {
            var gateway = new PaymentProcessor();


            var returnedtype = gateway.GetPayment(300);

            Assert.IsInstanceOf(typeof(ExpensicePaymentGateWay), returnedtype);
        }

        [Test]
        public void ReturnPremiumPaymentGateway_IfAmountIsGreaterThanFiveHundred()
        {
            var gateway = new PaymentProcessor();


            var returnedtype = gateway.GetPayment(900);

            Assert.IsInstanceOf(typeof(PremiumPaymentGateway), returnedtype);
        }
    }
}