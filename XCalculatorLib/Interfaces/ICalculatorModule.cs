using System;
using System.Collections.Generic;
using System.Text;

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

        ICalculatorValue Calculate(Func<ICalculatorPhase, ICalculatorPhase> phaseHandler);
    }
}
