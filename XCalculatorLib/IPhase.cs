using System.Collections.Generic;

namespace XCalculatorLib
{
    public interface IPhase
    {
        string Name
        {
            get;
        }

        string Description
        {
            get;
        }

        IReadOnlyList<IValue> Inputs
        {
            get;
        }
    }
}
