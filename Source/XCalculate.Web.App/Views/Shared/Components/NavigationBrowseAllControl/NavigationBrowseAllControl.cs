using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCalculate.Web.Core.Interfaces;

namespace XCalculate.Web.App.Components
{
    public class NavigationBrowseAllControl : ViewComponent
    {
        private readonly ICalculatorService calculatorService;

        public NavigationBrowseAllControl(ICalculatorService calculatorService)
        {
            this.calculatorService = calculatorService;
        }

#pragma warning disable 1998
        public async Task<IViewComponentResult> InvokeAsync()
#pragma warning restore 1998
        {
            var model = new NavigationBrowseAllControlModel
            {
                Count = this.calculatorService.GetCount()
            };

            return View("Default", model);
        }
    }
}
