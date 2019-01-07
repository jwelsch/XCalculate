using Microsoft.AspNetCore.Mvc;
using System;
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

            var vm = new CalculatorIndexModel()
            {
                Id = calculator.Id,
                Name = calculator.Module.Function.FunctionInfo.Name,
                Description = calculator.Module.Function.FunctionInfo.Description,
                Tags = calculator.Module.Function.FunctionInfo.Tags,
                Inputs = calculator.Module.Function.GetInputs().Select(i => new CalculatorValueModel() { ValueLabel = i.GetName(), ValueType = i.GetValueType(), UnitLabel = i.GetUnitLabel(), IsArray = i.IsArrayValue }).ToArray(),
                Results = calculator.Module.Function.FunctionInfo.ResultInfo.Select(i => new CalculatorValueModel() { ValueLabel = i.GetName(), UnitLabel = i.GetUnitLabel() }).ToArray()
            };

            return View(vm);
        }

        /// <summary>
        /// Calculates a phase of a calculator.
        /// </summary>
        /// <param name="calculatorId">ID of the calculator.</param>
        /// <param name="calculatorInput">Inputs of the calculator.</param>
        /// <returns>The calculation result.</returns>
        [Route("{calculatorId}/Calculate")]
        //[AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Calculate(int calculatorId, [FromBody] CalculatorInput calculatorInput)
        {
            var calculator = this.calculatorService.GetById(calculatorId);

            var valueInputs = calculator.Module.Function.GetInputs();

            for (var i = 0; i < valueInputs.Length; i++)
            {
                var input = calculatorInput.Inputs.FirstOrDefault(j => j.Key == valueInputs[i].Info.Name);

                if (input.Key != null && input.Value != null)
                {
                    valueInputs[i].Value = TypeConverter.ToObject<double>(input.Value);
                    continue;
                }

                var arrayInput = calculatorInput.ArrayInputs.FirstOrDefault(j => j.Key == valueInputs[i].Info.Name);

                if (arrayInput.Key != null && arrayInput.Value != null)
                {
                    valueInputs[i].Value = TypeConverter.ToArray<double[]>(arrayInput.Value);
                }
            }

            var result = calculator.Module.Function.Calculate(valueInputs);

            return Json(new CalculateResult(result));
        }
    }
}