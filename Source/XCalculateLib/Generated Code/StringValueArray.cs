namespace XCalculateLib
{
    public class StringArrayValue : BaseArrayValue<string>
    {
        public StringArrayValue(string[] value, StringArrayValueInfo info = null, Range lengthRange = null, ValueValidator<string[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}

