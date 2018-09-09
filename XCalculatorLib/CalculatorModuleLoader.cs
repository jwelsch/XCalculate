using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using XCalculatorLib.Interfaces;

namespace XCalculatorLib
{
    public static class CalculatorModuleLoader
    {
        public static ICalculatorModule[] Load(params string[] directoryPaths)
        {
            var modules = new List<ICalculatorModule>();

            foreach(var directoryPath in directoryPaths)
            {
                var dllFilePaths = Directory.GetFiles(directoryPath, "*.dll", SearchOption.AllDirectories);

                foreach (var dllFilePath in dllFilePaths)
                {
                    var module = LoadModule(dllFilePath);

                    modules.Add(module);
                }
            }

            return modules.ToArray();
        }

        private static ICalculatorModule LoadModule(string path)
        {
            var moduleAssembly = Assembly.LoadFile(path);
            moduleAssembly.
        }
    }
}
