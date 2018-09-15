using System;

namespace XCalculatorLib
{
    public interface IAssemblyInfo
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
