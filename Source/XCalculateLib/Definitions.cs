using System.Collections.Generic;

namespace XCalculateLib
{
    public delegate bool ValueValidator<T>(T value);

    public delegate IEnumerable<IValue> PhaseHandler(IPhase phase);
}