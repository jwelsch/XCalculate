using System;

namespace XCalculateLib
{
    public abstract class BaseValue<T> : IValue
    {
        private T value = default(T);

        private ValueValidator<T> Validator
        {
            get;
        }

        public IValueInfo Info
        {
            get;
        }

        public bool IsArrayValue
        {
            get { return false; }
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
            set
            {
                if (value.GetType() != this.ValueType)
                {
                    throw new ArgumentException($"The incoming type, {value.GetType()}, does not match the value type, {this.ValueType}.");
                }

                this.Value = (T)value;
            }
        }

        public virtual Type ValueType
        {
            get { return typeof(T); }
        }

        protected BaseValue(T value, IValueInfo info, ValueValidator<T> validator)
        {
            this.Info = info;

            // Set validator first since this.Value calls the validator.
            this.Validator = i =>
            {
                if (i != null && i.GetType().IsArray)
                {
                    throw new ArgumentException($"Use {typeof(BaseArrayValue<>)} for array types.");
                }
                return validator == null ? true : validator(i);
            };

            this.Value = value;
        }
    }
}
