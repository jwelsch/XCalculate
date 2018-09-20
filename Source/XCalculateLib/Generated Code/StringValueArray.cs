namespace XCalculateLib
{
    public class StringArrayValue : BaseArrayValue<string[]>
    {
        public StringArrayValue(string[] value, IValueInfo info = null, ValueValidator<string[]> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

