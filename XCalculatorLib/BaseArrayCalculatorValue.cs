
namespace XCalculatorLib
{
    public abstract class BaseArrayCalculatorValue<T> : BaseCalculatorValue<T[]>
    {
        public Range LengthRange
        {
            get;
            private set;
        }

        protected BaseArrayCalculatorValue(T[] value, ICalculatorValueInfo info, Range lengthRange = null, ValueValidator<T[]> validator = null)
            : base(value, info, i =>
            {
                lengthRange?.Within(i.Length);
                return validator == null ? true : validator(i);
            })
        {
            this.LengthRange = lengthRange ?? new Range(1, int.MaxValue);
        }
    }
}
