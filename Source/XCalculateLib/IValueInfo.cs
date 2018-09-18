using System;

namespace XCalculateLib
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
