using System;
using System.IO;
using Xunit;

namespace XCalculateManagerLib.Tests.Functional
{
    public class CalculatorModuleFactoryCreateFromFilesShould
    {
        [Fact]
        public void SuccessfullyCreateModulesFromSingleAbsolutePathFile()
        {
            var factory = new CalculatorModuleFactory();

            var directory = Path.GetFullPath(Path.Combine(Definitions.CalculatorDirectory, Definitions.CalculatorExtensionFileName));

            var module = factory.CreateFromFiles(directory);

            Assert.NotNull(module);
            Assert.NotEmpty(module);
        }

        [Fact]
        public void FailToCreateModulesFromSingleRelativePathFile()
        {
            var factory = new CalculatorModuleFactory();

            Assert.Throws<ArgumentException>(() =>
            {
                var module = factory.CreateFromFiles(Path.Combine(Definitions.CalculatorDirectory, Definitions.CalculatorExtensionFileName));
            });
        }

        [Fact]
        public void FailToCreateModulesFromNullFile()
        {
            var factory = new CalculatorModuleFactory();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var module = factory.CreateFromFiles(null);
            });
        }

        [Fact]
        public void FailToCreateModulesFromEmptyFile()
        {
            var factory = new CalculatorModuleFactory();

            Assert.Throws<ArgumentException>(() =>
            {
                var module = factory.CreateFromFiles(string.Empty);
            });
        }
    }
}
