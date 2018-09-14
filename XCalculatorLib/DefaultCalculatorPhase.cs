using System.Collections.Generic;

namespace XCalculatorLib
{
    public class DefaultCalculatorPhase : ICalculatorPhase
    {
        private readonly List<ICalculatorValue> inputs;

        public string Name
        {
            get;
            private set;
        }

        public string Description
        {
            get;
            private set;
        }

        public IReadOnlyList<ICalculatorValue> Inputs
        {
            get
            {
                return this.inputs;
            }
        }

        public DefaultCalculatorPhase(IEnumerable<ICalculatorValue> inputs)
        {
            this.inputs = new List<ICalculatorValue>(inputs);
        }

        public DefaultCalculatorPhase(string name, string description, params ICalculatorValue[] inputs)
            : this(name, description, new List<ICalculatorValue>(inputs))
        {
        }

        public DefaultCalculatorPhase(string name, string description, IEnumerable<ICalculatorValue> inputs)
            : this(inputs)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
