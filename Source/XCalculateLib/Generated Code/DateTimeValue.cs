namespace XCalculateLib
{
    public class DateTimeValue : BaseValue<System.DateTime>
    {
        public DateTimeValue(System.DateTime value, IValueInfo info = null, ValueValidator<System.DateTime> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

