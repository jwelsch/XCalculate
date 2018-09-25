using System;
using System.Linq;

namespace XCalculateLib
{
    public abstract class BaseFunction : IFunction
    {
        public IFunctionInfo FunctionInfo
        {
            get;
            private set;
        }

        public BaseFunction(IFunctionInfo functionInfo)
        {
            this.FunctionInfo = functionInfo;
        }

        public abstract IValue Calculate(PhaseHandler phaseHandler);

        protected static IValue[] DoPhase(PhaseHandler phaseHandler, IPhase phase)
        {
            if (phase == null)
            {
                throw new ArgumentNullException(nameof(phase));
            }

            phaseHandler?.Invoke(phase);

            return phase.Inputs.ToArray();
        }

        protected static T GetValue<T>(IValue value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (typeof(T).IsArray || value.Value.GetType().IsArray)
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
    }
}
