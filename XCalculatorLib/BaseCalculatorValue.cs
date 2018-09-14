using System;

namespace XCalculatorLib
{
    public abstract class BaseCalculatorValue<T> : ICalculatorValue
    {
        private T value = default(T);

        private ValueValidator<T> Validator
        {
            get;
            set;
        }

        public ICalculatorValueInfo Info
        {
            get;
        }

        public T Value
        {
            get { return this.value; }

            set
            {
                this.Validator?.Invoke(value);
                this.value = value;
            }
        }

        object ICalculatorValue.Value
        {
            get { return this.Value; }
            set { this.Value = (T)value; }
        }

        public Type ValueType
        {
            get { return typeof(T); }
        }

        protected BaseCalculatorValue(T value, ICalculatorValueInfo info, ValueValidator<T> validator)
        {
            this.Info = info;
            this.Value = value;
            this.Validator = validator;
        }
    }
}
