﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using XCalculate.Web.App.Models;
using XCalculate.Web.Core.Interfaces;
using XCalculateLib;

namespace XCalculate.Web.App.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculatorService calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            this.calculatorService = calculatorService;
        }

        [Route("[controller]/{calculatorId}")]
        [HttpGet]
        public IActionResult Index([FromRoute] int calculatorId)
        {
            var calculator = this.calculatorService.GetById(calculatorId);

            var vm = new CalculatorIndexModel
            {
                Id = calculator.Id,
                Name = calculator.Module.Function.FunctionInfo.Name,
                Description = calculator.Module.Function.FunctionInfo.Description,
                Tags = calculator.Module.Function.FunctionInfo.Tags,
                Inputs = calculator.Module.Function.GetInputs().Select(i => new CalculatorValueModel { ValueLabel = i.GetName(), ValueType = i.GetValueType(), UnitLabel = i.GetUnitLabel(false), IsArray = i.IsArrayValue, Value = i.Value }).ToArray(),
                Results = calculator.Module.Function.FunctionInfo.ResultInfo.Select(i => new CalculatorValueModel { ValueLabel = i.GetName(), UnitLabel = i.GetUnitLabel(false) }).ToArray()
            };

            return View(vm);
        }

        /// <summary>
        /// Calculates a phase of a calculator.
        /// </summary>
        /// <param name="calculatorId">ID of the calculator.</param>
        /// <param name="calculatorInput">Inputs of the calculator.</param>
        /// <returns>The calculation result.</returns>
        [Route("[controller]/{calculatorId}/Calculate")]
        //[AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Calculate(int calculatorId, [FromBody] CalculatorInput calculatorInput)
        {
            var calculator = this.calculatorService.GetById(calculatorId);

            var valueInputs = calculator.Module.Function.GetInputs();

            for (var i = 0; i < valueInputs.Length; i++)
            {
                var input = calculatorInput.Inputs.FirstOrDefault(j => j.Key.Replace("_", " ") == valueInputs[i].Info.Name);

                if (input.Key != null && input.Value != null)
                {
                    try
                    {
                        valueInputs[i].Value = TypeConverter.ToObject<double>(input.Value);
                    }
                    catch (Exception ex)
                    {
                        return this.BadRequest(new CalculateResult($"Bad value for input \"{valueInputs[i].Info.Name}\": {ex.Message}"));
                    }

                    continue;
                }

                var arrayInput = calculatorInput.ArrayInputs.FirstOrDefault(j => j.Key.Replace("_", " ") == valueInputs[i].Info.Name);

                if (arrayInput.Key != null && arrayInput.Value != null)
                {
                    try
                    {
                        valueInputs[i].Value = TypeConverter.ToArray<double[]>(arrayInput.Value);
                    }
                    catch (Exception ex)
                    {
                        return this.BadRequest(new CalculateResult($"Bad value for input \"{valueInputs[i].Info.Name}\": {ex.Message}"));
                    }
                }
            }

            try
            {
                var result = calculator.Module.Function.Calculate(valueInputs);

                return Json(new CalculateResult(result));
            }
            catch (Exception ex)
            {
                return this.BadRequest(new CalculateResult($"An error occurred during calculation: {ex.Message}."));
            }
        }
    }
}