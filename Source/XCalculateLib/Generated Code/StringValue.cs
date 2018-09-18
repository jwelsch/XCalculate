namespace XCalculateLib
{
    public class StringValue : BaseValue<string>
    {
        public StringValue(string value, StringValueInfo info = null, ValueValidator<string> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

