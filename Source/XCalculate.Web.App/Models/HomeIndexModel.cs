using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace XCalculate.Web.App.Models
{
    public class HomeIndexModel
    {
        public IList<CalculatorLink> CalculatorLinks

        {
            get;
            set;
        }
    }
}
