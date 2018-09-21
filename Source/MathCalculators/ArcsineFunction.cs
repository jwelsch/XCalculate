﻿using System;
using XCalculateLib;

namespace MathCalculators
{
    public class ArcsineFunction : BaseFunction
    {
        public ArcsineFunction()
            : base(new DefaultFunctionInfo(new Version("1.0.0"), "Arcsine", "Find the arcsine of an angle.", "arcsine", "arcsin"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new DefaultPhase(
                "Specify Operands",
                "Specify angle to find the arcsine of.",
                new AgnosticValue(0.0, new ValueInfo("Angle")));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Asin(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}