using FiveCode.Application.Contract.Data;
using FiveCode.Domain;

namespace FiveCode.Data.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentsRepository
    {
        private FiveCodeDbContext _dbContext;

        public PaymentRepository(FiveCodeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}