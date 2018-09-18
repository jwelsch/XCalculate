using System;

namespace XCalculateLib
{
    public abstract class BaseValueInfo<T> : IValueInfo
    {
        public string Name
        {
            get;
        }

        public string Description
        {
            get;
        }

        public Type ValueType
        {
            get
            {
                return typeof(T);
            }
        }

        public string UnitName
        {
            get;
        }

        protected BaseValueInfo(string name = null, string description = null, string unitName = null)
        {
            this.Name = name;
            this.Description = description;
            this.UnitName = unitName;
        }
    }
}
