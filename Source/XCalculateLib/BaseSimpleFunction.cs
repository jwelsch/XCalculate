using System;

namespace XCalculateLib
{
    public abstract class BaseSimpleFunction<T> : ISimpleFunction<T>
    {
        public IFunctionInfo FunctionInfo
        {
            get;
            private set;
        }

        public BaseSimpleFunction(IFunctionInfo functionInfo)
        {
            this.FunctionInfo = functionInfo;
        }

        public abstract T Calculate(params T[] values);

        public IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(new IValue[] { new ArrayValue<T[]>(new T[0]) });

            phaseHandler?.Invoke(phase);

            ArrayValue<T> valueArray = null;
            var once = false;

            foreach (var i in phase.Inputs)
            {
                if (once)
                {
                    throw new InvalidOperationException("More than one value returned from phase.");
                }

                valueArray = i as ArrayValue<T>;

                if (valueArray == null)
                {
                    throw new InvalidOperationException($"Phase returned type {i.GetType()}, which could not be cast to {typeof(ArrayValue<T>)}.");
                }

                once = true;
            }

            if (valueArray == null)
            {
                throw new InvalidOperationException("No value returned from phase.");
            }

            var result = this.Calculate(valueArray.Value);

            return new Value<T>(result);
        }
    }
}
