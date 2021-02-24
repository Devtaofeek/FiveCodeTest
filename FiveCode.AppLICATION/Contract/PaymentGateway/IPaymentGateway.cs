using FiveCode.Application.Features.Payment.Command;
using FiveCode.Domain;
using System.Threading.Tasks;

namespace FiveCode.Application.Contract.PaymentGateway
{
    public interface IPaymentGateway
    {
        public Task<bool> Pay(decimal Amount, bool Retry = false);
    }
}