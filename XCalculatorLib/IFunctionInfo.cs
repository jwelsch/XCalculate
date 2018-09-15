using System;

namespace XCalculatorLib
{
    public interface IFunctionInfo
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
