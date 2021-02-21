using FluentValidation;
using System;

namespace FiveCode.Application.Features.Payment.Command
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidator()
        {
            RuleFor(p => p.CreditCardNumber).NotEmpty().WithMessage("Credit card Number is required").
                CreditCard().WithMessage("Credit card number is invalid");
            RuleFor(p => p.CardHolder).NotEmpty().WithMessage("Credit card holder's name is required");
            RuleFor(p => p.ExpirationDate).NotEmpty().WithMessage("Credit Card expiry date is required").GreaterThan(DateTime.Now).WithMessage("Credit Card has expired");
            RuleFor(p => p.SecurityCode).MaximumLength(3).WithMessage("security code is invalid");
            RuleFor(p => p.Amount).NotEmpty().GreaterThan(0).WithMessage("enter a correct value");
        }
    }
}