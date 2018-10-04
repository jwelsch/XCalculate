using System.Collections.Generic;

namespace XCalculateLib
{
    public class FirstPhase : Phase
    {
        public FirstPhase(string name, string description, params IValue[] inputs)
            : base(0, name, description, true, inputs, null)
        {
        }

        //public FirstPhase(string name, string description, IValue input)
        //    : this(name, description, new IValue[] { input })
        //{
        //}

        //public FirstPhase(IEnumerable<IValue> inputs)
        //    : this(null, null, inputs)
        //{
        //}

        public FirstPhase(params IValue[] inputs)
            : this(null, null, inputs)
        {
        }
    }
}
