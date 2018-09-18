using System;

namespace XCalculateLib
{
    public interface IValue
    {
        IValueInfo Info
        {
            get;
        }

        object Value
        {
            get;
            set;
        }

        Type ValueType
        {
            get;
        }
    }
}
