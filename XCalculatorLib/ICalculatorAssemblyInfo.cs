using System;
using System.Reflection;

namespace XCalculatorLib
{
    public interface ICalculatorAssemblyInfo
    {
        Version Version
        {
            get;
        }

        IAuthorInfo AuthorInfo
        {
            get;
        }
    }
}
