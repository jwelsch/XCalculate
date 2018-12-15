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

        public async Task<IViewComponentResult> InvokeAsync(int calculatorId, IPhase phase)
        {
            var model = new CalculatorPhaseControlModel()
            {
                CalculatorId = calculatorId,
                PhaseId = phase.Id,
                Name = phase.Name,
                Description = phase.Description,
                Inputs = phase.Inputs
            };

            return View("Default", model);
        }
    }
}
