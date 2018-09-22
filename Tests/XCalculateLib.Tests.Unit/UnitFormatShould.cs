using Xunit;

namespace XCalculateLib.Tests.Unit
{
    public class UnitFormatShould
    {
        [Fact]
        public void SuccessfullyFormatValueOfOne()
        {
            var value = 1.0;
            var nameSingular = "foobar";
            var namePlural = "foobars";
            var abreviationSingular = "fb";
            var abreviationPlural = "fbs";

            var unit = new XCalculateLib.Unit(nameSingular, namePlural, abreviationSingular, abreviationPlural);

            var nameFormat = unit.Format(value);
            var abreviationFormat = unit.Format(value, true);

            Assert.Equal($"{value} {nameSingular}", nameFormat);
            Assert.Equal($"{value} {abreviationSingular}", abreviationFormat);
        }

        [Fact]
        public void SuccessfullyFormatValueOfMoreThanOne()
        {
            var value = 2.0;
            var nameSingular = "Foobar";
            var namePlural = "Foobars";
            var abreviationSingular = "fb";
            var abreviationPlural = "fbs";

            var unit = new XCalculateLib.Unit(nameSingular, namePlural, abreviationSingular, abreviationPlural);

            var nameFormat = unit.Format(value);
            var abreviationFormat = unit.Format(value, true);

            Assert.Equal($"{value} {namePlural}", nameFormat);
            Assert.Equal($"{value} {abreviationPlural}", abreviationFormat);
        }

        [Fact]
        public void SuccessfullyFormatValueOfOneWithMinimalArgumentsWhenConstructed()
        {
            var value = 1.0;
            var nameSingular = "Foobar";

            var unit = new XCalculateLib.Unit(nameSingular);

            var nameFormat = unit.Format(value);
            var abreviationFormat = unit.Format(value, true);

            Assert.Equal($"{value} {nameSingular}", nameFormat);
            Assert.Equal($"{value}", abreviationFormat);
        }

        [Fact]
        public void SuccessfullyFormatValueOfMoreThanOneWithMinimalArgumentsWhenConstructed()
        {
            var value = 2.0;
            var nameSingular = "Foobar";

            var unit = new XCalculateLib.Unit(nameSingular);

            var nameFormat = unit.Format(value);
            var abreviationFormat = unit.Format(value, true);

            Assert.Equal($"{value}", nameFormat);
            Assert.Equal($"{value}", abreviationFormat);
        }
    }
}
