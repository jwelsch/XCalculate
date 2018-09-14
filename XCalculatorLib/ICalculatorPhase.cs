using System.Collections.Generic;

namespace XCalculatorLib
{
    public interface ICalculatorPhase
    {
        string Name
        {
            get;
        }

        string Description
        {
            get;
        }

        IReadOnlyList<ICalculatorValue> Inputs
        {
            get;
        }
    }
}
