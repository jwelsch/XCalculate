using System.Collections.Generic;
using XCalculatorLib;

namespace XCalculatorManagerLib
{
    public interface ICalculatorModuleFactory
    {
        IEnumerable<IModule> CreateFromDirectories(params string[] directoryPaths);

        IEnumerable<IModule> CreateFromFiles(params string[] filePaths);
    }
}
