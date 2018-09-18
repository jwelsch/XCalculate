using System.Collections.Generic;

namespace XCalculateLib
{
    public interface IPhase
    {
        string Name
        {
            get;
        }

        string Description
        {
            get;
        }

        IReadOnlyList<IValue> Inputs
        {
            get;
        }
    }
}
