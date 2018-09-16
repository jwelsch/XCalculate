using System;
using System.IO;
using System.Linq;
using System.Reflection;
using XCalculatorManagerLib;
using XCalculatorLib;

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

                var addModule = modules.First(i => i.Function.FunctionInfo.Name == "Simple Add");

                if (addModule != null)
                {
                    var result = addModule.Function.Calculate(p =>
                    {
                        p.Inputs[0].Value = new int[] { 1, 2, 3 };

                        return p.Inputs;
                    });
                }

                //if (addModule != null)
                //{
                //    var result = ((ISimpleFunction<int>)addModule.Function).Calculate(1, 2, 3);
                //}

                //modules = moduleFactory.CreateFromFiles(new string[] { Path.Combine(directoryPath, "MathCalculators.dll") });
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
