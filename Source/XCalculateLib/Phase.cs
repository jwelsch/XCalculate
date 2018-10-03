using System.Collections.Generic;
using System.Linq;

namespace XCalculateLib
{
    public class Phase : IPhase
    {
        public int Id
        {
            get;
        }

        public string Name
        {
            get;
        }

        public string Description
        {
            get;
        }

        public bool IsFinal
        {
            get;
        }

        public IValue[] Inputs
        {
            get;
        }

        public IValue[] Results
        {
            get;
        }

        public Phase(IEnumerable<IValue> inputs, IEnumerable<IValue> results)
            : this(0, null, null, true, inputs, results)
        {
        }

        public Phase(int id, string name, string description, bool isFinal, IEnumerable<IValue> inputs, IEnumerable<IValue> results)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.IsFinal = isFinal;
            this.Inputs = inputs?.ToArray();
            this.Results = results?.ToArray();
        }
    }
}
