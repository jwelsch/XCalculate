using System;

namespace XCalculatorLib.Interfaces
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
