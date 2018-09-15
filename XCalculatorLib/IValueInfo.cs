using System;

namespace XCalculatorLib
{
    public interface IValueInfo
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
