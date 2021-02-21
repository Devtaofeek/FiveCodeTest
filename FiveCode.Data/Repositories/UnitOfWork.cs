using FiveCode.Application.Contract.Data;
using System.Threading.Tasks;

namespace FiveCode.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPaymentHistoryRepository PaymentHistoryRepository { get; set; }
        public IPaymentsRepository PaymentRepository { get; set; }

        private FiveCodeDbContext _dbContext;

        public UnitOfWork(FiveCodeDbContext dbContext)
        {
            _dbContext = dbContext;
            PaymentHistoryRepository = new PaymentHistoryRepository(dbContext);
            PaymentRepository = new PaymentRepository(dbContext);
        }

        public async Task<int> complete()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}