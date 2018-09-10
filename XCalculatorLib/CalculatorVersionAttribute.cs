using System;

namespace XCalculatorLib
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class CalculatorVersionAttribute : Attribute
    {
        public string Version
        {
            get;
        }

        // This is a positional argument
        public CalculatorVersionAttribute(string version)
        {
            this.Version = version;
        }
    }
}
