using System;
using System.IO;
using Xunit;

namespace XCalculatorManagerLib.Functional
{
    public class CalculatorModuleFactoryCreateFromDirectoriesShould
    {
        [Fact]
        public void SuccessfullyCreateModulesFromSingleAbsolutePathDirectory()
        {
            var factory = new CalculatorModuleFactory();

            var directory = Path.GetFullPath(Definitions.CalculatorDirectory);

            var module = factory.CreateFromDirectories(directory);

            Assert.NotNull(module);
            Assert.NotEmpty(module);
        }

        [Fact]
        public void FailToCreateModulesFromSingleRelativePathDirectory()
        {
            var factory = new CalculatorModuleFactory();

            Assert.Throws<ArgumentException>(() =>
            {
                var module = factory.CreateFromDirectories(Definitions.CalculatorDirectory);
            });
        }

        [Fact]
        public void FailToCreateModulesFromNullDirectory()
        {
            var factory = new CalculatorModuleFactory();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var module = factory.CreateFromDirectories(null);
            });
        }

        [Fact]
        public void FailToCreateModulesFromEmptyDirectory()
        {
            var factory = new CalculatorModuleFactory();

            Assert.Throws<ArgumentException>(() =>
            {
                var module = factory.CreateFromDirectories(string.Empty);
            });
        }
    }
}
