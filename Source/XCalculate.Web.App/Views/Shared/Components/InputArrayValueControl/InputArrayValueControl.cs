using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCalculateLib;

namespace XCalculate.Web.App.Components
{
    public class InputArrayValueControl : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IValue input, string onInputCallback)
        {
            var model = new InputArrayValueControlModel()
            {
            };

            return View("Default", model);
        }
    }
}
