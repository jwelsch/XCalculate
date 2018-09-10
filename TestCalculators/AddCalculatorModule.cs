using System;
using System.Collections.Generic;
using XCalculatorLib;

namespace TestCalculators
{
    [CalculatorVersion("1.0.0")]
    public class AddCalculatorModule : ICalculatorModule
    {
        public string Name
        {
            get
            {
                return "Addition";
            }
        }

        public string Description
        {
            get
            {
                return "Adds two numbers together";
            }
        }

        public string[] Tags
        {
            get
            {
                return new string[] { "add" };
            }
        }

        public ICalculatorValue Calculate(Func<ICalculatorPhase, IEnumerable<ICalculatorValue>> phaseHandler)
        {
            if (phaseHandler == null)
            {
                throw new ArgumentNullException(nameof(phaseHandler));
            }

            var values = phaseHandler(new DefaultCalculatorPhase("Specify Addends", "Specify two numbers to add together", new ICalculatorValueInfo[]
                {
                    new Int32CalculatorValueInfo("First", "The first number"),
                    new Int32CalculatorValueInfo("Second", "The second number")
                }));

            var sum = 0;

            foreach(Int32CalculatorValue value in values)
            {
                sum += value.Value;
            }

            return new Int32CalculatorValue(sum);
        }
    }
}
