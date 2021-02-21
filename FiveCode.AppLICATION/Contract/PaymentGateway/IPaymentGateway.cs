using FiveCode.Application.Features.Payment.Command;
using FiveCode.Domain;

namespace FiveCode.Application.Contract.PaymentGateway
{
    public interface IPaymentGateway
    {
        public PaymentStatus Pay(CreatePaymentCommand paymentCommand);
    }
}