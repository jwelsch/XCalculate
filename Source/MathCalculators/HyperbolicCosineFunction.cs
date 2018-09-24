﻿using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicCosineFunction : BaseFunction
    {
        public HyperbolicCosineFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Hyperbolic Cosine", "Find the hyperbolic cosine of an angle.", "hyperbolic", "cosine", "cosh"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Argument",
                "Specify angle to find the hyperbolic cosine of.",
                new AgnosticValue(0.0, new ValueInfo("Angle", null, new RadianUnit())));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Cosh(GetValue<double>(values[0]));

            return new AgnosticValue(result);
        }
    }
}
