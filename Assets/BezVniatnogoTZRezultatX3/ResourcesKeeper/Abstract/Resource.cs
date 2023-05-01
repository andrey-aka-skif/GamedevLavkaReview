using System;
using System.Collections.Generic;

namespace Assets.BezVniatnogoTZRezultatX3.Abstract
{
    public abstract class Resource : ValueObject
    {
        private const string DEFAULT_NAME = "Ресурс";
        private const string VALIDATE_ERROR_MESSAGE = "Значение не должно быть меньше нуля";

        public virtual string Name => DEFAULT_NAME;

        public int Amount { get; }

        protected Resource(int amount)
        {
            if (amount < 1)
                throw new ArgumentException(VALIDATE_ERROR_MESSAGE, nameof(amount));

            Amount = amount;
        }

        public static implicit operator int(Resource value) => value.Amount;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Amount;
        }

        public override string ToString() => Amount.ToString();
    }
}
