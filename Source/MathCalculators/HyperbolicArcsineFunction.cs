﻿using System;
using XCalculateLib;

namespace MathCalculators
{
    public class HyperbolicArcsineFunction : BaseFunction
    {
        public HyperbolicArcsineFunction()
            : base(new DefaultFunctionInfo(new Version("1.0.0"), "Hyperbolic Arcsine", "Find the hyperbolic arcsine of an angle.", "hyperbolic", "arcsine", "arcsinh"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new DefaultPhase(
                "Specify Operands",
                "Specify angle to find the hyperbolic arcsine of.",
                new AgnosticValue(0.0, new ValueInfo("Angle")));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Asinh(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
