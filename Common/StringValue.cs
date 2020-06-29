namespace Bitnovo.Common
{
    public class StringValue : ValueObject<StringValue>
    {
        public string Value { get; private set; }

        protected StringValue(string value)
        {
            Value = value;
        }

        public static Result<StringValue> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Fail<StringValue>("value should not be empty");

            return Result.Ok(new StringValue(value));
        }

        public override string ToString()
        {
            return Value;
        }

        protected override bool EqualsCore(StringValue other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static implicit operator StringValue(string value)
        {
            return Create(value).Value;
        }

        public static implicit operator string(StringValue value)
        {
            return value.Value;
        }
    }
}
