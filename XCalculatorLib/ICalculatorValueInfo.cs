using System;

namespace XCalculatorLib
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
