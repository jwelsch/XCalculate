using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCalculateLib;

namespace XCalculate.Web.App.Components
{
    public class CalculatorPhaseControlModel
    {
        public int CalculatorId
        {
            get;
            set;
        }

        public int PhaseId
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

        public IValue[] Inputs
        {
            get;
            set;
        }
    }
}
