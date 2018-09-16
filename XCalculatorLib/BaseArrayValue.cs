
namespace XCalculatorLib
{
    public abstract class BaseArrayValue<T> : BaseValue<T[]>
    {
        public Range LengthRange
        {
            get;
            private set;
        }

        public new T[] Value
        {
            get
            {
                return base.Value;
            }
        }

        protected BaseArrayValue(T[] value, IValueInfo info, Range lengthRange = null, ValueValidator<T[]> validator = null)
            : base(value, info, i =>
            {
                if (i != null)
                {
                    lengthRange?.Within(i.Length);
                }
                return validator == null ? true : validator(i);
            })
        {
            this.LengthRange = lengthRange ?? new Range(0, int.MaxValue);
        }
    }
}
