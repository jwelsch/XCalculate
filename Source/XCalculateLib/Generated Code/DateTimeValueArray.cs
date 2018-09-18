namespace XCalculateLib
{
    public class DateTimeArrayValue : BaseArrayValue<System.DateTime>
    {
        public DateTimeArrayValue(System.DateTime[] value, IValueInfo info = null, Range lengthRange = null, ValueValidator<System.DateTime[]> validator = null)
            : base(value, info, lengthRange, validator)
        {
        }
    }
}

