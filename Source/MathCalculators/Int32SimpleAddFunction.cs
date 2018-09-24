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
            return values.Aggregate((x, y) => x + y);
        }
    }
}
