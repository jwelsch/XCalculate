using System;
using System.Collections.Generic;
using System.Text;

namespace XCalculatorLib.Interfaces
{
    public interface ICalculatorValue
    {
        ICalculatorValueInfo Info
        {
            get;
        }

        object Value
        {
            get;
            set;
        }
    }
}
