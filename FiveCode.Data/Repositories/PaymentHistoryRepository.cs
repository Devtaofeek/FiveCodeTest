using FiveCode.Application.Contract.Data;
using FiveCode.Domain;

namespace FiveCode.Data.Repositories
{
    public class PaymentHistoryRepository : BaseRepository<PaymentHistory>, IPaymentHistoryRepository
    {
        private FiveCodeDbContext _dbContext;

        public PaymentHistoryRepository(FiveCodeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}