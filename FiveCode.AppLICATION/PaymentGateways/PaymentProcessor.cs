using FiveCode.Application.Contract.PaymentGateway;
using FiveCode.Application.Features.Payment.Command;
using FiveCode.Domain;

namespace FiveCode.Application.PaymentGateways
{
    public class PaymentProcessor : IPaymentProcessor
    {
        private ICheapPaymentGateway _cheapPaymentGateWay;
        private IExpensicePaymentGateWay _expensicePaymentGateWay;
        private IPremiumPaymentGateway _premiumPaymentGateway;

        public PaymentProcessor()
        {
            _cheapPaymentGateWay = new CheapPaymentGateway();
            _expensicePaymentGateWay = new  ExpensicePaymentGateWay();
            _premiumPaymentGateway = new  PremiumPaymentGateway();
        }

        public IPaymentGateway GetPayment(decimal Amount)
        {
            switch (Amount)
            {
                case < 20:
                   return _cheapPaymentGateWay;
                case >= 21 and <= 500:
                    return _expensicePaymentGateWay;
                case > 500:
                    {
                       return _premiumPaymentGateway;
                    }
            }
            return default;
        }
    }
}