using FiveCode.Domain;
using Microsoft.EntityFrameworkCore;

namespace FiveCode.Data
{
    public class FiveCodeDbContext : DbContext
    {
        public FiveCodeDbContext(DbContextOptions<FiveCodeDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentHistory> PaymentHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PaymentHistory>().Property(c => c.PaymentStatus).HasConversion<int>();
        }
    }
}