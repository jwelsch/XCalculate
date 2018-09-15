using System;

namespace XCalculatorLib
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
