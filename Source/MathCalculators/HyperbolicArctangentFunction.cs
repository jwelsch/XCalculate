﻿using System;
using XCalculateLib;

namespace MathCalculators
{
    public class HyperbolicArctangentFunction : BaseFunction
    {
        public HyperbolicArctangentFunction()
            : base(new DefaultFunctionInfo(new Version("1.0.0"), "Hyperbolic Arctangent", "Find the hyperbolic arctangent of an angle.", "hyperbolic", "arctangent", "arctanh"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new DefaultPhase(
                "Specify Operands",
                "Specify angle to find the hyperbolic arctangent of.",
                new AgnosticValue(0.0, new ValueInfo("Angle")));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Atanh(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}