namespace XCalculateLib
{
    public class ArrayValue<T> : BaseArrayValue<T>
    {
        public ArrayValue(T[] value, IValueInfo info = null, Range lengthRange = null, ValueValidator<T[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}
