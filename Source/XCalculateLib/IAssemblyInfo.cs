using System;

namespace XCalculateLib
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
