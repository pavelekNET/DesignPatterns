namespace Commons.Repository.Models
{
    public class Money
    {
        private decimal Value { get; }

        public Money(decimal value)
        {
            Value = value;
        }

        #region '=='
        public static bool operator ==(Money money1, Money money2)
        {
            var result = Equals(money1, money2);
            return result;
        }

        #endregion

        #region '!='
        public static bool operator !=(Money money1, Money money2)
        {
            return !(money1 == money2);
        }

        #endregion

        #region '>'

        public static bool operator >(Money money1, Money money2)
        {
            return money1.Value > money2.Value;
        }

        #endregion

        #region '<'

        public static bool operator <(Money money1, Money money2)
        {
            return money1.Value < money2.Value;
        }

        #endregion

        #region '>='

        public static bool operator >=(Money money1, Money money2)
        {
            return money1.Value >= money2.Value;
        }

        #endregion

        #region '<='

        public static bool operator <=(Money money1, Money money2)
        {
            return money1.Value <= money2.Value;
        }

        #endregion

        #region '+'

        public static Money operator +(Money money1, Money money2)
        {
            return new Money(money1.Value + money2.Value);
        }

        #endregion

        #region '-'

        public static Money operator -(Money money1, Money money2)
        {
            return new Money(money1.Value - money2.Value);
        }

        #endregion

        #region overrides
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            // Do not use == operator here, stackOverflow can happen!
            var other = obj as Money;
            if (object.Equals(other, null))
            {
                return false;
            }

            return this.Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
        #endregion
    }
}