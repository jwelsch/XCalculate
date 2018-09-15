using System;

namespace XCalculatorLib
{
    public interface ICalculatorFunctionInfo
    {
        string Name
        {
            get;
        }

        string Description
        {
            get;
        }

        string[] Tags
        {
            get;
        }

        Version Version
        {
            get;
        }
    }
}
