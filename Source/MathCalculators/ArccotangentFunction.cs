﻿using System;
using XCalculateLib;

namespace MathCalculators
{
    public class ArccotangentFunction : BaseFunction
    {
        public ArccotangentFunction()
            : base(new DefaultFunctionInfo(new Version("1.0.0"), "Arccotangent", "Find the tangent of an angle.", "arccotangent", "arccot"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new DefaultPhase(
                "Specify Operands",
                "Specify angle to find the tangent of.",
                new AgnosticValue(0.0, new ValueInfo("Angle")));

            var values = DoPhase(phaseHandler, phase);

            var result = 1.0 / Math.Atan(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}