using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace XCalculate.Web.App.Models
{
    public class CalculatorInput
    {
        public Dictionary<string, string> Inputs
        {
            get;
            set;
        }

        public Dictionary<string, string[]> ArrayInputs
        {
            get;
            set;
        }

        public CalculatorInput()
        {
            this.Inputs = new Dictionary<string, string>();
            this.ArrayInputs = new Dictionary<string, string[]>();
        }
    }
}
