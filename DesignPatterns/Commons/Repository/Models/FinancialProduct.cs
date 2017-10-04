namespace Commons.Repository.Models
{
    public class FinancialProduct
    {
        public PositiveMoney PriceWithoutVat { get; }

        public PositiveMoney PriceWithVat { get; }

        public string Description { get; }
    }
}