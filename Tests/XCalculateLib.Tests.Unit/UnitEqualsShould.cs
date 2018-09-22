using Xunit;

namespace XCalculateLib.Tests.Unit
{
    public class UnitEqualsShould
    {
        [Fact]
        public void ReturnTrueWhenComparingTwoEqualUnits()
        {
            var nameSingular1 = "foobar";
            var namePlural1 = "foobars";
            var abreviationSingular1 = "fb";
            var abreviationPlural1 = "fbs";

            var nameSingular2 = "foobar";
            var namePlural2 = "foobars";
            var abreviationSingular2 = "fb";
            var abreviationPlural2 = "fbs";

            var unit1 = new XCalculateLib.Unit(nameSingular1, namePlural1, abreviationSingular1, abreviationPlural1);
            var unit2 = new XCalculateLib.Unit(nameSingular2, namePlural2, abreviationSingular2, abreviationPlural2);

            Assert.True(unit1.Equals(unit2));
        }

        [Fact]
        public void ReturnFalseWhenComparingTwoUnequalUnits()
        {
            var nameSingular1 = "foobar1";
            var namePlural1 = "foobar1s";
            var abreviationSingular1 = "fb1";
            var abreviationPlural1 = "fb1s";

            var nameSingular2 = "foobar2";
            var namePlural2 = "foobar2s";
            var abreviationSingular2 = "fb2";
            var abreviationPlural2 = "fb2s";

            var unit1 = new XCalculateLib.Unit(nameSingular1, namePlural1, abreviationSingular1, abreviationPlural1);
            var unit2 = new XCalculateLib.Unit(nameSingular2, namePlural2, abreviationSingular2, abreviationPlural2);

            Assert.False(unit1.Equals(unit2));
        }

        [Fact]
        public void ReturnFalseWhenComparingAgainstNull()
        {
            var nameSingular1 = "foobar1";
            var namePlural1 = "foobar1s";
            var abreviationSingular1 = "fb1";
            var abreviationPlural1 = "fb1s";

            var unit1 = new XCalculateLib.Unit(nameSingular1, namePlural1, abreviationSingular1, abreviationPlural1);

            Assert.False(unit1.Equals(null));
        }
    }
}
