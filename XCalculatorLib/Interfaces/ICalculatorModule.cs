using System;
using System.Collections.Generic;

namespace XCalculatorLib.Interfaces
{
    public interface ICalculatorModule
    {
        string Name
        {
            get;
        }

        string Description
        {
            get;
        }

        string[] Tags
        {
            get;
        }

        ICalculatorValue Calculate(Func<ICalculatorPhase, IEnumerable<ICalculatorValue>> phaseHandler);
    }
}
