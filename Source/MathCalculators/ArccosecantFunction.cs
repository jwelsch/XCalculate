﻿using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ArccosecantFunction : BaseFunction
    {
        public ArccosecantFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Arccosecant", "Find the arccosecant of an angle.", "arccosecant", "arccsc"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Argument",
                "Specify angle to find the arccosecant of.",
                new AgnosticValue(0.0, new ValueInfo("Angle", null, new RadianUnit())));

            var values = DoPhase(phaseHandler, phase);

            var result = 1.0 / Math.Acos(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
