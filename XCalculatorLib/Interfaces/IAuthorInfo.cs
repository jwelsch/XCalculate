using System;

namespace XCalculatorLib.Interfaces
{
    public interface IAuthorInfo
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
