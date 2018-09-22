﻿using System;
using XCalculateLib;

namespace MathCalculators
{
    public class ArccotangentFunction : BaseFunction
    {
        public ArccotangentFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Arccotangent", "Find the arccotangent of an angle.", "arccotangent", "arccot"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Operands",
                "Specify angle to find the arccotangent of.",
                new AgnosticValue(0.0, new ValueInfo("Angle")));

            var values = DoPhase(phaseHandler, phase);

            var result = 1.0 / Math.Atan(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
