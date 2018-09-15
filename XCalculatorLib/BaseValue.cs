using System;

namespace XCalculatorLib
{
    public abstract class BaseValue<T> : IValue
    {
        private T value = default(T);

        private ValueValidator<T> Validator
        {
            get;
            set;
        }

        public IValueInfo Info
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

        object IValue.Value
        {
            get { return this.Value; }
            set { this.Value = (T)value; }
        }

        public Type ValueType
        {
            get { return typeof(T); }
        }

        protected BaseValue(T value, IValueInfo info, ValueValidator<T> validator)
        {
            this.Info = info;
            this.Value = value;
            this.Validator = validator;
        }
    }
}
