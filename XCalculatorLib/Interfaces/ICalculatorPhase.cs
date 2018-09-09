using System;
using System.Collections.Generic;
using System.Text;

namespace XCalculatorLib.Interfaces
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

        IReadOnlyList<ICalculatorValueInfo> InputInfos
        {
            get;
        }

        void SetInputs(IEnumerable<ICalculatorValue> inputs);
    }
}
