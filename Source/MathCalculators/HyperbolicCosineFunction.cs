﻿using System;
using XCalculateLib;

namespace MathCalculators
{
    public class HyperbolicCosineFunction : BaseFunction
    {
        public HyperbolicCosineFunction()
            : base(new DefaultFunctionInfo(new Version("1.0.0"), "Hyperbolic Cosine", "Find the hyperbolic cosine of an angle.", "cosh", "hyperbolic"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new DefaultPhase(
                "Specify Operands",
                "Specify angle to find the hyperbolic cosine of.",
                new AgnosticValue(0.0, new ValueInfo("Angle")));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Cosh(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}