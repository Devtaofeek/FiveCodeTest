using FiveCode.Application.Contract.PaymentGateway;
using FiveCode.Application.Features.Payment.Command;
using FiveCode.Domain;
using System.Threading.Tasks;

namespace FiveCode.Application.PaymentGateways
{
    public class PremiumPaymentGateway : IPremiumPaymentGateway
    {
        public Task<bool> Pay(decimal Amount, bool Retry)
        {
            throw new System.NotImplementedException();
        }

      
    }
}