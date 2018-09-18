namespace XCalculateLib
{
    public class StringValue : BaseValue<string>
    {
        public StringValue(string value, IValueInfo info = null, ValueValidator<string> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

