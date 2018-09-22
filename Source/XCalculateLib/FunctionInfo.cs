
using System;

namespace XCalculateLib
{
    public class FunctionInfo : IFunctionInfo
    {
        public string Name
        {
            get;
            protected set;
        }

        public string Description
        {
            get;
            protected set;
        }

        public string[] Tags
        {
            get;
            protected set;
        }

        public Version Version
        {
            get;
            protected set;
        }

        public FunctionInfo(Version version, string name, string description = null, params string[] tags)
        {
            this.Version = version;
            this.Name = name;
            this.Description = description;
            this.Tags = tags;
        }
    }
}
