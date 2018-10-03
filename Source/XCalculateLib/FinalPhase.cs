using System.Collections.Generic;

namespace XCalculateLib
{
    public class FinalPhase : Phase
    {
        public FinalPhase(int id, string name, string description, IEnumerable<IValue> results)
            : base( id, name, description, true, null, results)
        {
        }

        public FinalPhase(int id, string name, string description, IValue result)
            : this(id, name, description, new IValue[] { result })
        {
        }

        public FinalPhase(int id, IEnumerable<IValue> results)
            : this(id, null, null,  results)
        {
        }

        public FinalPhase(int id, IValue result)
            : this(id, null, null, result)
        {
        }

        public FinalPhase(IEnumerable<IValue> results)
            : this(int.MinValue, null, null, results)
        {
        }

        public FinalPhase(IValue result)
            : this(int.MinValue, null, null, result)
        {
        }
    }
}
