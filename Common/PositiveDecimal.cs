using System;
using System.Collections.Generic;
using System.Text;

namespace Bitnovo.Common
{
    public class PositiveDecimal : ValueObject<PositiveDecimal>
    {
        public decimal Value { get; private set; }

        private PositiveDecimal() { }

        protected PositiveDecimal(decimal value)
        {
            Value = value;
        }

        public static Result<PositiveDecimal> Create(decimal value)
        {
            if (value < 0)
                return Result.Fail<PositiveDecimal>("value should be greater than 0");

            return Result.Ok(new PositiveDecimal(value));
        }

        public Result<PositiveDecimal> Add(PositiveDecimal value)
            => Create(Value + value.Value);

        public Result<PositiveDecimal> Subtract(PositiveDecimal value)
            => Create(Value - value.Value);

        protected override bool EqualsCore(PositiveDecimal other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static implicit operator PositiveDecimal(decimal value)
        {
            return Create(value).Value;
        }

        public static implicit operator decimal(PositiveDecimal value)
        {
            return value.Value;
        }
    }
}