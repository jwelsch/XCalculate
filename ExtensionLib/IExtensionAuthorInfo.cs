using System;

namespace ExtensionLib
{
    public interface IExtensionAuthorInfo
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
