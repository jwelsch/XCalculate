namespace XCalculatorLib
{
    public class ArrayValue<T> : BaseArrayValue<T>
    {
        public ArrayValue(T[] value, ArrayValueInfo<T> info = null, Range lengthRange = null, ValueValidator<T[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}
