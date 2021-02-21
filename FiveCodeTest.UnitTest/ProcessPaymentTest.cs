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
            var gateway = new PaymentProcessor(new CheapPaymentGateway(),
                new ExpensicePaymentGateWay(),
                new PremiumPaymentGateway());
            var paymentcom = new CreatePaymentCommand()
            {
                Amount = 15
            };
            var returnedtype = gateway.ProcessPayment(paymentcom);

            Assert.IsInstanceOf(typeof(CheapPaymentGateway), returnedtype);
        }

        [Test]
        public void ReturnExpensivePaymentGateway_IfAmountIsGreaterThanTwentyOneAndLessThanOrEqualTOFiveHundred()
        {
            var gateway = new PaymentProcessor(new CheapPaymentGateway(),
                new ExpensicePaymentGateWay(),
                new PremiumPaymentGateway());
            var paymentcom = new CreatePaymentCommand()
            {
                Amount = 70
            };
            var returnedtype = gateway.ProcessPayment(paymentcom);

            Assert.IsInstanceOf(typeof(ExpensicePaymentGateWay), returnedtype);
        }

        [Test]
        public void ReturnPremiumPaymentGateway_IfAmountIsGreaterThanFiveHundred()
        {
            var gateway = new PaymentProcessor(new CheapPaymentGateway(),
                new ExpensicePaymentGateWay(),
                new PremiumPaymentGateway());
            var paymentcom = new CreatePaymentCommand()
            {
                Amount = 700
            };
            var returnedtype = gateway.ProcessPayment(paymentcom);

            Assert.IsInstanceOf(typeof(PremiumPaymentGateway), returnedtype);
        }
    }
}