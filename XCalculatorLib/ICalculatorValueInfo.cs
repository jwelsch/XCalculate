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

        string UnitName
        {
            get;
        }
    }
}
