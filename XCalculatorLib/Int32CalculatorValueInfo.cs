using System;
using System.Collections.Generic;
using System.Text;

namespace XCalculatorLib
{
    public class Int32CalculatorValueInfo : BaseCalculatorValueInfo<int>
    {
        public Int32CalculatorValueInfo(string name = null, string description = null, string unitName = null)
            : base(name, description, unitName)
        {
        }
    }
}
