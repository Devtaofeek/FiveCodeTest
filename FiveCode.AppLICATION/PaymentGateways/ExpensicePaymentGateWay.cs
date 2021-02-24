using FiveCode.Application.Contract.PaymentGateway;
using FiveCode.Application.Features.Payment.Command;
using FiveCode.Domain;
using System;
using System.Threading.Tasks;

namespace FiveCode.Application.PaymentGateways
{
    public class ExpensicePaymentGateWay : IExpensicePaymentGateWay
    {
        private ICheapPaymentGateway _cheapPaymentGateWay;
        private readonly bool isExpensivePaymentGatewayAvailable;
        public ExpensicePaymentGateWay()
        {
            var random = new Random().Next(200);
            isExpensivePaymentGatewayAvailable = random % 2 == 0;
            _cheapPaymentGateWay = new CheapPaymentGateway();
        }
        public Task<bool> Pay(decimal Amount, bool Retry)
        {
            if (!(Amount > 20 && Amount <= 500))
            {
                throw new ArgumentException("Expensive Payment Gateway can only process amounts between 21-500 pounds");
            }
            if (isExpensivePaymentGatewayAvailable)
            {
                var random = new Random().Next(100);
                return Task.FromResult(random % 2 == 0);
            }

            return _cheapPaymentGateWay.Pay(Amount,true);
        }

        
    }
}