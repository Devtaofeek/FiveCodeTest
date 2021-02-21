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
        private PaymentStatus result;

        public PaymentProcessor(ICheapPaymentGateway cheapPaymentGateWay,
            IExpensicePaymentGateWay expensicePaymentGateWay,
            IPremiumPaymentGateway premiumPaymentGateway)
        {
            _cheapPaymentGateWay = cheapPaymentGateWay;
            _expensicePaymentGateWay = expensicePaymentGateWay;
            _premiumPaymentGateway = premiumPaymentGateway;
        }

        public IPaymentGateway ProcessPayment(CreatePaymentCommand request)
        {
            IPaymentGateway paymentGateway = _cheapPaymentGateWay;

            switch (request.Amount)
            {
                case < 20:
                    paymentGateway = _cheapPaymentGateWay;
                    result = paymentGateway.Pay(request);
                    break;

                case >= 21 and <= 500:
                    paymentGateway = _expensicePaymentGateWay;
                    result = paymentGateway.Pay(request);
                    if (result == PaymentStatus.Failed)
                    {
                        paymentGateway = _cheapPaymentGateWay;
                        result = paymentGateway.Pay(request);
                    }
                    break;

                case > 500:
                    {
                        paymentGateway = _premiumPaymentGateway;
                        result = paymentGateway.Pay(request);
                        var count = 0;
                        while (result == PaymentStatus.Failed && count < 3)
                        {
                            result = paymentGateway.Pay(request);
                            count++;
                        }

                        break;
                    }
            }
            return paymentGateway;
        }

        public PaymentStatus ReturnPaymentStatus()
        {
            return result;
        }
    }
}