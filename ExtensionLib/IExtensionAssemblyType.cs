using System;

namespace ExtensionLib
{
    public interface IExtensionAssemblyType
    {
        Type ExportType
        {
            get;
        }

        Type MatchType
        {
            get;
        }
    }
}
