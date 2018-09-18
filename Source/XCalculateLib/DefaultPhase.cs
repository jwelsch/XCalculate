using System.Collections.Generic;

namespace XCalculateLib
{
    public class DefaultPhase : IPhase
    {
        private readonly List<IValue> inputs;

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

        public IReadOnlyList<IValue> Inputs
        {
            get
            {
                return this.inputs;
            }
        }

        public DefaultPhase(IEnumerable<IValue> inputs)
        {
            this.inputs = new List<IValue>(inputs);
        }

        public DefaultPhase(string name, string description, params IValue[] inputs)
            : this(name, description, new List<IValue>(inputs))
        {
        }

        public DefaultPhase(string name, string description, IEnumerable<IValue> inputs)
            : this(inputs)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
