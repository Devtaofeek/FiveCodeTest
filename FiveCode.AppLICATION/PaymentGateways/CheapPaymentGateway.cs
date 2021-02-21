using FiveCode.Application.Contract.PaymentGateway;
using FiveCode.Application.Features.Payment.Command;
using FiveCode.Domain;

namespace FiveCode.Application.PaymentGateways
{
    public class CheapPaymentGateway : ICheapPaymentGateway
    {
        PaymentStatus IPaymentGateway.Pay(CreatePaymentCommand paymentCommand)
        {
            return PaymentStatus.Processed;
        }
    }
}