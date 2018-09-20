using System;

namespace XCalculateLib
{
    public abstract class BaseArrayValue<T> : IValue
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

        public T Value
        {
            get { return this.value; }

            set
            {
                if (value != null)
                {
                    if (!value.GetType().IsArray)
                    {
                        throw new ArgumentException("The value must be an array type.", nameof(value));
                    }
                }

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

        protected BaseArrayValue(T value, IValueInfo info, ValueValidator<T> validator)
        {
            this.Info = info;
            this.Validator = validator;
            this.Value = value;
        }
    }
}
