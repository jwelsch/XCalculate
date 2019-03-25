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
#pragma warning disable 1998
        public async Task<IViewComponentResult> InvokeAsync(IValue input, string onInputCallback)
#pragma warning restore 1998
        {
            var model = new InputArrayValueControlModel()
            {
            };

            return View("Default", model);
        }
    }
}
