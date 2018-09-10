using System;

namespace XCalculatorLib
{
    public abstract class BaseCalculatorValueInfo<T> : ICalculatorValueInfo
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

        protected BaseCalculatorValueInfo(string name = null, string description = null, string unitName = null)
        {
            this.Name = name;
            this.Description = description;
            this.UnitName = unitName;
        }
    }
}
