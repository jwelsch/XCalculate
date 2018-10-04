using System;
using System.Collections.Generic;
using System.Text;

namespace XCalculateLib
{
    public interface IPhaseCollection : ICollection<IPhase>, IEnumerable<IPhase>, IList<IPhase>
    {
        IPhaseCollection AddPhase(IPhase phase);
    }
}
