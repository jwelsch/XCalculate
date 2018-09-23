﻿using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class CosineFunction : BaseFunction
    {
        public CosineFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Cosine", "Find the cosine of an angle.", "cosine", "cos"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Argument",
                "Specify angle to find the cosine of.",
                new AgnosticValue(0.0, new ValueInfo("Angle", null, new RadianUnit())));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Cos(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
