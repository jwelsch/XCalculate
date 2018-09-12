using System;
using System.IO;
using System.Reflection;
using XCalculatorManagerLib;

namespace XCalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var directoryPath = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);

                var moduleFactory = new CalculatorModuleFactory();
                var modules = moduleFactory.CreateFromDirectories(directoryPath);

                modules = moduleFactory.CreateFromFiles(new string[] { Path.Combine(directoryPath, "TestCalculators.dll") });
            }
            catch (Exception ex)
            {
                var message = $"Unhandled exception:{Environment.NewLine}{ex}";
                System.Diagnostics.Trace.WriteLine(message);
                Console.WriteLine(message);
            }
        }
    }
}
