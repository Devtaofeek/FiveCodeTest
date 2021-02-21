using FiveCode.Application.Contract.PaymentGateway;
using FiveCode.Application.Features.Payment.Command;
using FiveCode.Domain;

namespace FiveCode.Application.PaymentGateways
{
    public class ExpensicePaymentGateWay : IExpensicePaymentGateWay
    {
        PaymentStatus IPaymentGateway.Pay(CreatePaymentCommand paymentCommand)
        {
            return PaymentStatus.Pending;
        }
    }
}