
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

        public IValueInfo[] ResultInfo
        {
            get;
            protected set;
        }

        public FunctionInfo(Version version, string name, IValueInfo[] resultInfo, string description = null, params string[] tags)
        {
            this.Version = version;
            this.Name = name;
            this.ResultInfo = resultInfo;
            this.Description = description;
            this.Tags = tags;
        }

        public FunctionInfo(Version version, string name, IValueInfo resultInfo, string description = null, params string[] tags)
            : this(version, name, new IValueInfo[] { resultInfo }, description, tags)
        {
        }
    }
}
