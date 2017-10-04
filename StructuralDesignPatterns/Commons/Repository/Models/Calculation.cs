using System;

namespace Commons.Repository.Models
{
    public class Calculation
    {
        public string Label { get; }

        public FinancialProduct FinancialProduct { get; }

        public Calculation(string label, FinancialProduct financialProduct)
        {
            if(string.IsNullOrEmpty(label)) throw new ArgumentException(label);
            if(financialProduct == null) throw new ArgumentNullException();

            Label = label;
            FinancialProduct = financialProduct;
        }
    }
}
