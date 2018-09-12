using System.Collections.Generic;
using XCalculatorLib;

namespace XCalculatorManagerLib
{
    public interface ICalculatorModuleFactory
    {
        IEnumerable<ICalculatorModule> CreateFromDirectories(params string[] directoryPaths);

        IEnumerable<ICalculatorModule> CreateFromFiles(params string[] filePaths);
    }
}
