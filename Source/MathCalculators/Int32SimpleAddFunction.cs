using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class Int32SimpleAddFunction : BaseSimpleFunction<int>
    {
        public Int32SimpleAddFunction()
            : base(new DefaultFunctionInfo(new Version("1.0.0"), "Simple Add", "Add numbers together.", "add"))
        {
        }

        public override int Calculate(params int[] values)
        {
            var result = 0;

            foreach (var value in values)
            {
                result += value;
            }

            return result;
        }
    }
}
