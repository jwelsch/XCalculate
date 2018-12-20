using System;

namespace XCalculateLib
{
    public class ValueInfo : IValueInfo
    {
        public string Name
        {
            get;
        }

        public string Description
        {
            get;
        }

        public IUnit Unit
        {
            get;
        }

        public ValueInfo(string name = null, string description = null, IUnit unit = null)
        {
            this.Name = name;
            this.Description = description;
            this.Unit = unit;
        }
    }
}
