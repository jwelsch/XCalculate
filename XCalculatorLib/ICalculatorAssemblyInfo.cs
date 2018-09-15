using System;

namespace XCalculatorLib
{
    public interface ICalculatorAssemblyInfo
    {
        string Name
        {
            get;
        }

        string Email
        {
            get;
        }

        Uri Site
        {
            get;
        }
    }
}
