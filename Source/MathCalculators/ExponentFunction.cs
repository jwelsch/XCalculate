using System;
using System.Linq;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ExponentFunction : IFunction
    {
        public IFunctionInfo FunctionInfo
        {
            get;
            private set;
        }

        public ExponentFunction()
        {
            this.FunctionInfo = new DefaultFunctionInfo(new Version("1.0.0"), "Exponent", "Raise a number to an exponent.", "exponent");
        }

        public IValue Calculate(PhaseHandler phaseHandler)
        {
            if (phaseHandler == null)
            {
                throw new ArgumentNullException(nameof(phaseHandler));
            }

            var phase = new DefaultPhase(
                "Specify Operands",
                "Specify exponential equation.",
                new AgnosticValue(0.0, new ValueInfo("Base")),
                new AgnosticValue(0.0, new ValueInfo("Exponent")));

            var phaseValues = phaseHandler(phase);

            var values = phaseValues.ToArray();

            var result = Math.Pow(TypeConverter.ToObject<double>(values[0].Value), TypeConverter.ToObject<double>(values[1].Value));

            return new AgnosticValue(result);
        }
    }
}
