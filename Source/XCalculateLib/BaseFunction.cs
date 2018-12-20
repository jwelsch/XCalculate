using System;
using System.Linq;

namespace XCalculateLib
{
    public abstract class BaseFunction : IFunction
    {
        public IFunctionInfo FunctionInfo
        {
            get;
        }

        protected IValue[] Inputs
        {
            get;
        }

        protected BaseFunction(IFunctionInfo functionInfo, IValue[] inputs)
        {
            this.FunctionInfo = functionInfo;
            this.Inputs = inputs;
        }

        protected BaseFunction(IFunctionInfo functionInfo, IValue inputs)
            : this(functionInfo, new IValue[] { inputs })
        {
        }

        public IValue[] GetInputs()
        {
            return this.Inputs;
        }

        public abstract IValue[] Calculate(IValue[] inputs);

        protected void CheckInputs(IValue[] inputs)
        {
            if (inputs.Length != this.Inputs.Length)
            {
                throw new ArgumentException($"Expected {this.Inputs.Length} inputs.", nameof(inputs));
            }

            foreach (var input in this.Inputs)
            {
                var found = inputs.FirstOrDefault(i => i.Info.Name == input.Info.Name);

                if (found == null)
                {
                    throw new ArgumentException($"Input \"{input.Info.Name}\" was not found.", nameof(inputs));
                }
            }
        }

        protected static T GetValue<T>(IValue value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (typeof(T).IsArray || (value.Value != null && value.Value.GetType().IsArray))
            {
                throw new ArgumentException("Use BaseFunction.GetValues<T> for array types.");
            }

            return TypeConverter.ToObject<T>(value.Value);
        }

        protected static T GetValues<T>(IValue value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (!typeof(T).IsArray && !value.Value.GetType().IsArray)
            {
                throw new ArgumentException("Use BaseFunction.GetValue<T> for non-array types.");
            }

            return TypeConverter.ToArray<T>((Array)value.Value);
        }

        protected IValue[] CreateResults(object[] values)
        {
            if (this.FunctionInfo.ResultInfo.Length != values.Length)
            {
                throw new ArgumentException($"Expected {this.FunctionInfo.ResultInfo.Length} result values.");
            }

            var j = 0;
            return values.Select(i => new AgnosticValue(i, this.FunctionInfo.ResultInfo[j++])).ToArray();
        }

        protected IValue[] CreateResults(object value)
        {
            return this.CreateResults(new object[] { value });
        }
    }
}
