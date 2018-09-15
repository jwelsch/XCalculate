using System.Collections.Generic;

namespace XCalculatorLib
{
    public delegate bool ValueValidator<T>(T value);

    public delegate IEnumerable<ICalculatorValue> PhaseHandler(ICalculatorPhase phase);
}