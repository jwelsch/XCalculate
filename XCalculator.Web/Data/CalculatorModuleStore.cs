using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Linq;
using XCalculatorManagerLib;

namespace XCalculator.Web.Data
{
    public static class CalculatorModuleStore
    {
        public static FileSystemWatcher FileSystemWatcher;

        public static void InitializeCalculatorStore(this IServiceCollection services, string calculatorDirectory)
        {
            var di = Directory.CreateDirectory(calculatorDirectory);
            var fullDirectoryPath = di.FullName;

            var factory = new CalculatorModuleFactory();
            var repository = new CalculatorRepository();

            FileSystemWatcher = new FileSystemWatcher()
            {
                Path = calculatorDirectory,
                Filter = "*.dll",
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
                EnableRaisingEvents = true
            };

            FileSystemWatcher.Changed += (s, e) =>
            {
                LoadRepository(repository, fullDirectoryPath);
            };

            FileSystemWatcher.Created += (s, e) =>
            {
                LoadRepository(repository, fullDirectoryPath);
            };

            FileSystemWatcher.Deleted += (s, e) =>
            {
                LoadRepository(repository, fullDirectoryPath);
            };

            LoadRepository(repository, fullDirectoryPath);

            services.AddSingleton<ICalculatorRepository>(repository);
        }

        private static void LoadRepository(CalculatorRepository repository, string calculatorDirectory)
        {
            var factory = new CalculatorModuleFactory();
            var modules = factory.CreateFromDirectories(calculatorDirectory);

            int id = 0;

            repository.UpdateStore(modules.Select(i => new Calculator(++id, i)));
        }
    }
}
