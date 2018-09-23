using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCalculate.Web.Core.Interfaces;

namespace XCalculate.Web.App.Models
{
    public class HomeIndexViewModel
    {
        public IList<string> CalculatorNames
        {
            get;
            set;
        }
    }
}
