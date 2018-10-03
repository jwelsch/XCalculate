using System;
using System.Collections.Generic;
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

        protected IPhaseCollection Phases
        {
            get;
        }

        public BaseFunction(IFunctionInfo functionInfo)
            : this(functionInfo, new PhaseCollection())
        {
        }

        public BaseFunction(IFunctionInfo functionInfo, IPhaseCollection phases)
        {
            this.FunctionInfo = functionInfo;
            this.Phases = phases;
        }

        //public abstract IValue Calculate(PhaseHandler phaseHandler);

        public abstract IPhase Calculate(IPhase currentPhase = null);

        public IValue[] CurrentResult
        {
            get;
            private set;
        }

        protected void SetCurrentResult(IEnumerable<IValue> values)
        {
            this.CurrentResult = values.ToArray();
        }

        protected void SetCurrentResult(IValue value)
        {
            this.SetCurrentResult(new IValue[] { value });
        }

        protected void SetCurrentResult(object value)
        {
            this.SetCurrentResult(new IValue[] { new AgnosticValue(value) });
        }

        protected IPhase SetFinalResult(IEnumerable<IValue> values)
        {
            this.SetCurrentResult(values);

            return null;
        }

        protected IPhase SetFinalResult(IValue value)
        {
            return this.SetFinalResult(new IValue[] { value });
        }

        protected IPhase SetFinalResult(object value)
        {
            return this.SetFinalResult(new IValue[] { new AgnosticValue(value) });
        }

        protected IPhase SingleCalculate(IPhase currentPhase, IPhase firstPhase, Func<IValue, object> calculator)
        {
            if (currentPhase == null)
            {
                return firstPhase;
            }

            return this.SetFinalResult(new AgnosticValue(calculator(currentPhase.Inputs.First())));
        }

        protected IPhase SingleCalculate(IPhase currentPhase, IPhase firstPhase, Func<IValue[], object> calculator)
        {
            if (currentPhase == null)
            {
                return firstPhase;
            }

            return this.SetFinalResult(new AgnosticValue(calculator(currentPhase.Inputs)));
        }

        protected IPhase SingleCalculate(IPhase currentPhase, IPhase firstPhase, Func<IValue[], object[]> calculator)
        {
            if (currentPhase == null)
            {
                return firstPhase;
            }

            return this.SetFinalResult(calculator(currentPhase.Inputs).Select(i => new AgnosticValue(i)));
        }

        //protected static IValue[] DoPhase(PhaseHandler phaseHandler, IPhase phase)
        //{
        //    if (phase == null)
        //    {
        //        throw new ArgumentNullException(nameof(phase));
        //    }

        //    phaseHandler?.Invoke(phase);

        //    return phase.Inputs.ToArray();
        //}

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
    }
}
