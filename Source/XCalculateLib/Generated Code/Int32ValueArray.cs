namespace XCalculateLib
{
    public class Int32ArrayValue : BaseArrayValue<int[]>
    {
        public Int32ArrayValue(int[] value, IValueInfo info = null, ValueValidator<int[]> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

