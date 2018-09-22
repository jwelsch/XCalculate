using System;
using Xunit;

namespace XCalculateLib.Tests.Unit
{
    public class UnitConstructorShould
    {
        [Fact]
        public void SuccessfullyCreateObjectWithMinimalArguments()
        {
            var nameSingular = "Foobar";

            var unit = new XCalculateLib.Unit(nameSingular);

            Assert.NotNull(unit);
            Assert.Equal(nameSingular, unit.NameSingular);
            Assert.Null(unit.NamePlural);
            Assert.Null(unit.AbreviationPlural);
            Assert.Null(unit.AbreviationSingular);
        }

        [Fact]
        public void SuccessfullyCreateObjectWithAllArguments()
        {
            var nameSingular = "Foobar";
            var namePlural = "Foobars";
            var abreviationSingular = "fb";
            var abreviationPlural = "fbs";

            var unit = new XCalculateLib.Unit(nameSingular, namePlural, abreviationSingular, abreviationPlural);

            Assert.NotNull(unit);
            Assert.Equal(nameSingular, unit.NameSingular);
            Assert.Equal(namePlural, unit.NamePlural);
            Assert.Equal(abreviationSingular, unit.AbreviationSingular);
            Assert.Equal(abreviationPlural, unit.AbreviationPlural);
        }

        [Fact]
        public void FailWithNullSingularName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var unit = new XCalculateLib.Unit(null);
            });
        }

        [Fact]
        public void FailWithEmptySingularName()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var unit = new XCalculateLib.Unit(string.Empty);
            });
        }
    }
}
