using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using XCalculate.Web.Core.Interfaces;
using XCalculateLib;

namespace XCalculate.Web.App.Components
{
    public class CalculatorPhaseControl : ViewComponent
    {
        private readonly ICalculatorRepository repository;

        public CalculatorPhaseControl(ICalculatorRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int calculatorId, int phaseId)
        {
            var calculator = this.repository.GetById(calculatorId);

            IPhase phase = null;

            do
            {
                phase = calculator.Module.Function.Calculate(phase);
            }
            while (phase.Id != phaseId);

            var model = new CalculatorPhaseControlModel()
            {
                CalculatorId = calculator.Id,
                PhaseId = phase.Id,
                Name = phase.Name,
                Description = phase.Description,
                Inputs = phase.Inputs
            };

            return View("Default", model);
        }
    }
}
