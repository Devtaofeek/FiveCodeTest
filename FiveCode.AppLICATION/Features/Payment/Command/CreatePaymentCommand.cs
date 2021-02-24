using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FiveCode.Application.Features.Payment.Command
{
    public class CreatePaymentCommand : IRequest<Domain.PaymentStatus>, IValidatableObject
    {
        [Required]
        [MaxLength(19)]
        public string CreditCardNumber { get; set; }
        [Required]
        public string CardHolder { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }

        
        public  IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            CreatePaymentCommandValidator validator =
                new CreatePaymentCommandValidator();
         var validationresult =   validator.Validate(new CreatePaymentCommand { 
          Amount = this.Amount, SecurityCode = this.SecurityCode,
             ExpirationDate = this.ExpirationDate, 
             CardHolder = this.CardHolder, CreditCardNumber = this.CreditCardNumber
         });
           
          if (validationresult.Errors.Count != 0)
            {
                foreach (var item in validationresult.Errors)
                {
                    yield return new ValidationResult(item.ErrorMessage);
                }
            }
        }
    }
}