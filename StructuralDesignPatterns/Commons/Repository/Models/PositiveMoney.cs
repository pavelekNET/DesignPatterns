using System;

namespace Commons.Repository.Models
{
    public class PositiveMoney : Money
    {
        public PositiveMoney(decimal value) : base(value)
        {
            if(value < 0) throw new ArgumentException(nameof(value));
        }
    }
}
