using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCalculate.Web.Core.Interfaces;

namespace XCalculate.Web.App.Components.InputValue
{
    public class InputValueControl : ViewComponent
    {
        private ICalculatorRepository repository;

        public InputValueControl(ICalculatorRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int calculatorId, string onInputCallback)
        {
            var calculator = this.repository.GetById(calculatorId);

            var model = new InputValueControlModel()
            {
                Name = "Argument1",
                Description = "Argument1 description",
                UnitLabel = "Foobars",
                Value = null,
                OnInputCallback = onInputCallback
            };

            return View("Default", model);
        }
    }
}
