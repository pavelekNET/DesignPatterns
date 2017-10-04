using System.Data.Entity;

namespace Commons.Repository
{
    public class CalculationModuleDbContext : DbContext
    {
        public CalculationModuleDbContext() : base("name=CalculationModule")
        {
        }

        public DbSet<Persisted.Calculation> Calculations { get; set; }

        public DbSet<Persisted.FinancialProduct> FinancialProducts { get; set; }
    }
}
