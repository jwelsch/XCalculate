
namespace XCalculatorLib
{
    public abstract class BaseCalculatorValue<T> : ICalculatorValue
    {
        public ICalculatorValueInfo Info
        {
            get;
        }

        public object Value
        {
            get;
            set;
        }

        protected BaseCalculatorValue(ICalculatorValueInfo info, object value = null)
        {
            this.Info = info;
            this.Value = value;
        }
    }
}
