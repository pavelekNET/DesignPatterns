using Commons.Repository.Models;

namespace Commons.Repository.Persisted
{
    public class Calculation
    {
        public string Label { get; set; }

        public virtual FinancialProduct FinancialProduct { get; set; }
    }
}
