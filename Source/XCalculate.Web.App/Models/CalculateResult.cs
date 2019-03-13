using XCalculateLib;

namespace XCalculate.Web.App.Models
{
    public class CalculateResult
    {
        public bool IsError
        {
            get;
        }

        public string ErrorMessage
        {
            get;
        }

        public IValue[] Results
        {
            get;
        }

        protected CalculateResult(bool isError, string errorMessage, IValue[] results)
        {
            this.IsError = isError;
            this.ErrorMessage = errorMessage;
            this.Results = results;
        }

        public CalculateResult(IValue[] results)
            : this(false, null, results)
        {
        }

        public CalculateResult(string errorMessage)
            : this(true, errorMessage, null)
        {
        }
    }
}
