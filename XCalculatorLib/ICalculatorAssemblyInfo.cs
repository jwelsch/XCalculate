using System;

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
