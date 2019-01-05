﻿using Microsoft.AspNetCore.Mvc;
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
        /// <param name="inputs">Single inputs of the phase of the calculator.</param>
        /// <param name="arrayInputs">Array inputs of the phase of the calculator.</param>
        /// <returns>The calculation result.</returns>
        [Route("{calculatorId}/Calculate")]
        //[AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Calculate(int calculatorId, [FromBody] Dictionary<string, string> inputs, [FromBody] Dictionary<string, string[]> arrayInputs)
        {
            var calculator = this.calculatorService.GetById(calculatorId);

            var valueInputs = calculator.Module.Function.GetInputs();

            for (var i = 0; i < valueInputs.Length; i++)
            {
                var input = inputs.FirstOrDefault(j => j.Key == valueInputs[i].Info.Name);

                valueInputs[i].Value = TypeConverter.ToObject<double>(input.Value);
            }

            //foreach (var arrayInput in arrayInputs)
            //{
            //    var array = TypeConverter.ToArray<double[]>(arrayInput.Value);

            //    var arrayInputValue = new AgnosticArrayValue(array, new ValueInfo(arrayInput.Key));

            //    inputValues.Add(arrayInputValue);
            //}

            var result = calculator.Module.Function.Calculate(valueInputs);

            return Json(new CalculateResult(result));
        }
    }
}