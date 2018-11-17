using System.Collections.Generic;
using System.Linq;

namespace XCalculateLib
{
    public class PhaseTransition : IPhaseTransition
    {
        public int Id
        {
            get;
        }

        public IValue[] Inputs
        {
            get;
        }

        public PhaseTransition(int id, IEnumerable<IValue> inputs)
        {
            this.Id = id;
            this.Inputs = inputs.ToArray();
        }
    }
}
