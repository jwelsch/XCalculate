using System;
using System.Collections.Generic;
using System.Text;

namespace XCalculatorLib.Interfaces
{
    public interface ICalculatorValueInfo
    {
        string Name
        {
            get;
        }

        string Description
        {
            get;
        }

        Type ValueType
        {
            get;
        }

        string UnitName
        {
            get;
        }
    }
}
