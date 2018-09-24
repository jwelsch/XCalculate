﻿using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class CosecantFunction : BaseFunction
    {
        public CosecantFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Cosecant", "Find the cosecant of an angle.", "cosecant", "csc"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Argument",
                "Specify angle to find the cosecant of.",
                new AgnosticValue(0.0, new ValueInfo("Angle", null, new RadianUnit())));

            var values = DoPhase(phaseHandler, phase);

            var result = 1.0 / Math.Cos(GetValue<double>(values[0]));

            return new AgnosticValue(result);
        }
    }
}
