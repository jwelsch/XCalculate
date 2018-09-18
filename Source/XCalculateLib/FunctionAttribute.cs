using System;

namespace XCalculateLib
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class FunctionAttribute : Attribute
    {
    }
}
