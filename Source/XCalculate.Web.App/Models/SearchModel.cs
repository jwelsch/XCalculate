using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XCalculate.Web.App.Models
{
    public class SearchModel
    {
        public IList<int> CalculatorIds
        {
            get;
            set;
        }

        public IList<string> Filters
        {
            get;
            set;
        }
    }
}
