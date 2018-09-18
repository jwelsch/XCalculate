namespace XCalculateLib
{
    public class Value<T> : BaseValue<T>
    {
        public Value(T value, IValueInfo info = null, ValueValidator<T> validator = null)
            : base(value, info, validator)
        {
        }
    }
}
