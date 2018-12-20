using System;

namespace XCalculate.Web.App.Models
{
    public class CalculatorValueModel
    {
        public object Value
        {
            get;
            set;
        }

        public Type ValueType
        {
            get;
            set;
        }

        public string ValueLabel
        {
            get;
            set;
        }

        public string UnitLabel
        {
            get;
            set;
        }

        public bool IsArray
        {
            get;
            set;
        }
    }
}
