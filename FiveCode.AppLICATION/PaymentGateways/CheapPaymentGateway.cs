using FiveCode.Application.Contract.PaymentGateway;
using FiveCode.Application.Features.Payment.Command;
using FiveCode.Domain;
using System;
using System.Threading.Tasks;

namespace FiveCode.Application.PaymentGateways
{
    public class CheapPaymentGateway : ICheapPaymentGateway
    {

        public Task<bool> Pay(decimal Amount, bool Retry= false)
        {
            if (!Retry)
            {
                if(Amount > 20)
                {
                    throw new ArgumentOutOfRangeException("Cheap Payment Gateway can only process amounts < than 20 pounds.");
                }
            }

            var random = new Random().Next(100);
            return Task.FromResult(random % 2 == 0);
        }

       

       
    }
}