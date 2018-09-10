using System.Collections.Generic;
using XCalculatorLib;

namespace XCalculatorManagerLib
{
    public interface ICalculatorModuleFactory
    {
        IEnumerable<ICalculatorModule> Create(params string[] directoryPaths);
    }
}
