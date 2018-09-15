namespace XCalculatorLib
{
    public class Int16ArrayValue : BaseArrayValue<short>
    {
        public Int16ArrayValue(short[] value, Int16ArrayValueInfo info = null, Range lengthRange = null, ValueValidator<short[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}

