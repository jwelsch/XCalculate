using System;

namespace ExtensionLib
{
    internal class ExtensionAssemblyType : IExtensionAssemblyType
    {
        public Type ExportType
        {
            get;
            set;
        }

        public Type MatchType
        {
            get;
            set;
        }
    }
}
