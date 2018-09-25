﻿using System;
using System.Linq;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class SubtractFunction : BaseFunction
    {
        public SubtractFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Subtract", "Subtract numbers.", "subtract"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Operands",
                "Specify numbers to subtract.",
                new AgnosticArrayValue(
                    null,
                    new ValueInfo("Operands", "Operands to subtract."),
                    i => i != null && i.Length <= 1 ? throw new ArgumentException("Two or more values must be specified.") : true));

            var values = DoPhase(phaseHandler, phase);

            var arrayValues = GetValues<double[]>(values[0]);

            var difference = arrayValues.Aggregate((x, y) => x - y);

            return new AgnosticValue(difference);
        }
    }
}
