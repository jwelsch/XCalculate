namespace XCalculateLib
{
    public class Value<T> : BaseValue<T>
    {
        public Value(T value, ValueInfo<T> info = null, ValueValidator<T> validator = null)
            : base(value, info, validator)
        {
        }
    }
}
