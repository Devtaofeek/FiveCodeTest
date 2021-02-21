using System;
using System.Threading.Tasks;

namespace FiveCode.Application.Contract.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IPaymentHistoryRepository PaymentHistoryRepository { get; set; }
        IPaymentsRepository PaymentRepository { get; set; }

        Task<int> complete();
    }
}