using XCalculateLib;

namespace XCalculate.Web.App.Models
{
    public class CalculateResult
    {
        public IPhase Phase
        {
            get;
        }

        public IValue[] Results
        {
            get;
        }

        public CalculateResult(IPhase phase, IValue[] results)
        {
            this.Phase = phase;
            this.Results = results;
        }
    }
}
