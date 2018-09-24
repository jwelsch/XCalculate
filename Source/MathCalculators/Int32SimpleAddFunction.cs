using System;
using System.Linq;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class Int32SimpleAddFunction : BaseSimpleFunction<int>
    {
        public Int32SimpleAddFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Simple Add", "Add numbers.", "add"))
        {
        }

        public override int Calculate(params int[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.Length < 2)
            {
                throw new ArgumentException("Two or more values must be specified.", nameof(values));
            }

            return values.Aggregate((x, y) => x + y);
        }
    }
}
