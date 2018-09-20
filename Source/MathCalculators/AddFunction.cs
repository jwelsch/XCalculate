using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class AddFunction : IFunction
    {
        public IFunctionInfo FunctionInfo
        {
            get;
            private set;
        }

        public AddFunction()
        {
            this.FunctionInfo = new DefaultFunctionInfo(new Version("1.0.0"), "Add", "Add numbers together.", "add");
        }

        public IValue Calculate(PhaseHandler phaseHandler)
        {
            if (phaseHandler == null)
            {
                throw new ArgumentNullException(nameof(phaseHandler));
            }

            var phaseValues = phaseHandler(new DefaultPhase("Specify Operands", "Specify numbers to add together.", new AgnosticArrayValue(null, new ValueInfo("Operands", "Operands to add." ), i => i != null && i.Length <= 1 ? throw new ArgumentException("Two or more values must be specified.") : true)));

            var sum = 0.0;

            foreach (var phaseValue in phaseValues)
            {
                var arrayValue = (AgnosticArrayValue)phaseValue;

                var values = arrayValue.ToArray<double[]>();

                foreach (var value in values)
                {
                    sum += value;
                }
            }

            return new AgnosticValue(sum);
        }
    }
}
