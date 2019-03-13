using System;

namespace XCalculateLib
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

        IValueInfo[] ResultInfo
        {
            get;
        }
    }
}
