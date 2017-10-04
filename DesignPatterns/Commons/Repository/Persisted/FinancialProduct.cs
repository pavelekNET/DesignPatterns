namespace Commons.Repository.Persisted
{
    public class FinancialProduct : PersistentObject
    {
        public decimal PriceWithoutVat { get; set; }

        public decimal PriceWithVat { get; set; }

        public string Description { get; set; }
    }
}
