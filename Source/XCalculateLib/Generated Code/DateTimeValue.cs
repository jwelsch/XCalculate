namespace XCalculateLib
{
    public class DateTimeValue : BaseValue<System.DateTime>
    {
        public DateTimeValue(System.DateTime value, DateTimeValueInfo info = null, ValueValidator<System.DateTime> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

