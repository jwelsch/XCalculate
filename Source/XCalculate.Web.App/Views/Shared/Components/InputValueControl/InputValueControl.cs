using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using XCalculate.Web.Core.Interfaces;
using XCalculateLib;

namespace XCalculate.Web.App.Components
{
    public class InputValueControl : ViewComponent
    {
        private readonly ICalculatorRepository repository;

        public InputValueControl(ICalculatorRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync(IValue input, string onInputCallback)
        {
            var model = new InputValueControlModel()
            {
                Name = input?.Info.Name,
                Description = input?.Info.Description,
                UnitLabel = input?.Info.Unit.AbreviationPlural,
                Value = null,
                OnInputCallback = onInputCallback
            };

            return View("Default", model);
        }
    }
}
