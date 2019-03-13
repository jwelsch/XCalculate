using XCalculateLib;

namespace XCalculate.Web.App.Models
{
    public class CalculatorIndexModel
    {
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string[] Tags
        {
            get;
            set;
        }

        public CalculatorValueModel[] Inputs
        {
            get;
            set;
        }

        public CalculatorValueModel[] Results
        {
            get;
            set;
        }
    }
}
