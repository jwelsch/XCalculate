﻿using System;
using XCalculateLib;

namespace MathCalculators
{
    public class HyperbolicArccotangentFunction : BaseFunction
    {
        public HyperbolicArccotangentFunction()
            : base(new DefaultFunctionInfo(new Version("1.0.0"), "Hyperbolic Arccotangent", "Find the hyperbolic arccotangent of an angle.", "hyperbolic", "arccotangent", "arccoth"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new DefaultPhase(
                "Specify Operands",
                "Specify angle to find the hyperbolic arccotangent of.",
                new AgnosticValue(0.0, new ValueInfo("Angle")));

            var values = DoPhase(phaseHandler, phase);

            var result = 1.0 / Math.Atanh(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}