using System.Collections.Generic;

namespace XCalculateLib
{
    public interface IPhase : IPhaseTransition
    {
        string Name
        {
            get;
        }

        string Description
        {
            get;
        }

        bool IsFinal
        {
            get;
        }

        IValue[] Results
        {
            get;
        }
    }
}
