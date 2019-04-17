using System;
using XCalculateLib;

namespace PhysicsCalculators
{
    [Function]
    public class ForceFunction : BaseFunction
    {
        public ForceFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Force Equation", new ValueInfo("Force", "Force of an object"), "Calculates the force of an object.", "physics", "force"),
                  new AgnosticValue(0.0, new ValueInfo("Mass", "Mass of the object.")),
                  new AgnosticValue(0.0, new ValueInfo("Acceleration", "Acceleration of the object.")))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var mass = GetValue<double>(inputs[0]);
            var acceleration = GetValue<double>(inputs[1]);

            //
            // F = ma
            //
            var result = mass * acceleration;

            return this.CreateResults(result);
        }
    }
}
