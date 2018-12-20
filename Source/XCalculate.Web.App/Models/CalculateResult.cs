using XCalculateLib;

namespace XCalculate.Web.App.Models
{
    public class CalculateResult
    {
        public IValue[] Results
        {
            get;
        }

        public CalculateResult(IValue[] results)
        {
            this.Results = results;
        }
    }
}
