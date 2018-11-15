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

        public async Task<IViewComponentResult> InvokeAsync(int calculatorId, int phaseId, string valueName, string onInputCallback)
        {
            var calculator = this.repository.GetById(calculatorId);

            IPhase phase = null;

            do
            {
                phase = calculator.Module.Function.Calculate(phase);
            }
            while (phase.Id != phaseId);

            var value = phase.Inputs.FirstOrDefault(i => i.Info.Name == valueName);

            if (value == null)
            {
                throw new ArgumentException($"A value with the name {valueName} does not exist.", nameof(valueName));
            }

            var model = new InputValueControlModel()
            {
                Name = value?.Info.Name,
                Description = value?.Info.Description,
                UnitLabel = value?.Info.Unit.AbreviationPlural,
                Value = null,
                OnInputCallback = onInputCallback
            };

            return View("Default", model);
        }
    }
}
