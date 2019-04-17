using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ArcsineFunction : BaseFunction
    {
        public ArcsineFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Arcsine", new ValueInfo("Result", "The arcsine of the angle."), "Find the arcsine of an angle.", "arcsine", "arcsin"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the arcsine of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = Math.Asin(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
        //public ArcsineFunction()
        //    : base(new FunctionInfo(new Version("1.0.0"), "Arcsine", "Find the arcsine of an angle.", "arcsine", "arcsin"))
        //{
        //}

        //public override IPhase Calculate(IPhaseTransition transition = null)
        //{
        //    return this.SingleCalculate(transition,
        //        new FirstPhase(
        //            "Specify Argument",
        //            "Specify angle to find the arcsine of.",
        //            new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
        //        v => Math.Asin(GetValue<double>(v)));
        //}
    }
}
