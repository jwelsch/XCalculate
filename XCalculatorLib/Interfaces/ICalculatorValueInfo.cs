﻿using System;

namespace XCalculatorLib.Interfaces
{
    public interface ICalculatorValueInfo
    {
        string Name
        {
            get;
        }

        string Description
        {
            get;
        }

        Type ValueType
        {
            get;
        }

        string UnitName
        {
            get;
        }
    }
}
