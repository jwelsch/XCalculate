﻿using System;

namespace XCalculatorLib
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class CalculatorFunctionAttribute : Attribute
    {
    }
}
