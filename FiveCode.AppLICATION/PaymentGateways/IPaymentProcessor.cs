using FiveCode.Application.Contract.PaymentGateway;
using FiveCode.Application.Features.Payment.Command;
using FiveCode.Domain;

namespace FiveCode.Application.PaymentGateways
{
    public interface IPaymentProcessor
    {
        public IPaymentGateway GetPayment(decimal Amount);
    }
}