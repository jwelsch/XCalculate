using System.Collections.Generic;

namespace XCalculateLib
{
    public interface IPhase
    {
        int Id
        {
            get;
        }

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

        IValue[] Inputs
        {
            get;
        }

        IValue[] Results
        {
            get;
        }
    }
}
