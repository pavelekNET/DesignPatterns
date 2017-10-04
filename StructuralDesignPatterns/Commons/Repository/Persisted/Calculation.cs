namespace Commons.Repository.Persisted
{
    public class Calculation : PersistentObject
    {
        public string Label { get; set; }

        public virtual FinancialProduct FinancialProduct { get; set; }
    }
}
