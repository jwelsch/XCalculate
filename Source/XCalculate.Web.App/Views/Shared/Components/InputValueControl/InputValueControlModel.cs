using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XCalculate.Web.App.Components.InputValue
{
    public class InputValueControlModel
    {
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

        public string UnitLabel
        {
            get;
            set;
        }

        public object Value
        {
            get;
            set;
        }

        public string OnInputCallback
        {
            get;
            set;
        }
    }
}
