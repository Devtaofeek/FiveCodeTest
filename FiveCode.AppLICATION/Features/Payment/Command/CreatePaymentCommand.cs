using MediatR;
using System;

namespace FiveCode.Application.Features.Payment.Command
{
    public class CreatePaymentCommand : IRequest<Domain.PaymentStatus>
    {
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }
    }
}