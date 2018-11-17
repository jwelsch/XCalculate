using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using XCalculate.Web.App.Models;
using XCalculate.Web.Core.Interfaces;
using XCalculateLib;

namespace XCalculate.Web.App.Controllers
{
    [Route("[controller]")]
    public class CalculatorController : Controller
    {
        private readonly ICalculatorService calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            this.calculatorService = calculatorService;
        }

        [Route("{calculatorId}")]
        [HttpGet]
        public IActionResult Index(int calculatorId)
        {
            var calculator = this.calculatorService.GetById(calculatorId);

            var phase = calculator.Module.Function.Calculate();

            var vm = new CalculatorIndexModel()
            {
                Id = calculator.Id,
                Name = calculator.Module.Function.FunctionInfo.Name,
                Description = calculator.Module.Function.FunctionInfo.Description,
                Tags = calculator.Module.Function.FunctionInfo.Tags,
                PhaseId = phase.Id
            };

            return View(vm);
        }

        /// <summary>
        /// Calculates a phase of a calculator.
        /// </summary>
        /// <param name="calculatorId">ID of the calculator.</param>
        /// <param name="phaseId">ID of the phase of the calculator.</param>
        /// <param name="inputs">Single inputs of the phase of the calculator.</param>
        /// <param name="arrayInputs">Array inputs of the phase of the calculator.</param>
        /// <returns>The calculation result.</returns>
        [Route("{calculatorId}/Calculate/{phaseId}")]
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Calculate(int calculatorId, int phaseId, [FromBody] Dictionary<string, string> inputs, [FromBody] Dictionary<string, string[]> arrayInputs)
        {
            var calculator = this.calculatorService.GetById(calculatorId);

            var inputValues = new List<IValue>();

            foreach (var input in inputs)
            {
                var inputValue = new AgnosticValue(TypeConverter.ToObject<double>(input.Value), new ValueInfo(input.Key));

                inputValues.Add(inputValue);
            }

            foreach (var arrayInput in arrayInputs)
            {
                var array = TypeConverter.ToArray<double[]>(arrayInput.Value);

                var arrayInputValue = new AgnosticArrayValue(array, new ValueInfo(arrayInput.Key));

                inputValues.Add(arrayInputValue);
            }

            var transition = new PhaseTransition(phaseId, inputValues);

            var phase = calculator.Module.Function.Calculate(transition);

            return Json(phase);
        }
    }
}