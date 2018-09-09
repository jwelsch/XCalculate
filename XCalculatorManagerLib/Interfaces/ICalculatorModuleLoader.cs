using XCalculatorLib.Interfaces;

namespace XCalculatorManagerLib.Interfaces
{
    public interface ICalculatorModuleLoader
    {
        ICalculatorModule[] Load(ICalculatorAssemblyProvider assemblyProvider);
    }
}
