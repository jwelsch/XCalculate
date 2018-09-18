namespace XCalculateLib
{
    public class Int32Value : BaseValue<int>
    {
        public Int32Value(int value, IValueInfo info = null, ValueValidator<int> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

