using System;

namespace XCalculateLib
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
                var result = this.Validator?.Invoke(value);

                if (result != null && !result.Value)
                {
                    throw new ArgumentException("The value was not valid.");
                }
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
            this.Validator = validator;
            this.Value = value;
        }
    }
}
