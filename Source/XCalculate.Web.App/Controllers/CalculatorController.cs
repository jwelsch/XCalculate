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

        [Route("{id}")]
        [HttpGet]
        public IActionResult Index(int id)
        {
            var calculator = this.calculatorService.GetById(id);

            var vm = new CalculatorIndexModel()
            {
                Id = calculator.Id,
                Name = calculator.Module.Function.FunctionInfo.Name,
                Description = calculator.Module.Function.FunctionInfo.Description,
                Tags = calculator.Module.Function.FunctionInfo.Tags
            };

            return View(vm);
        }

        [Route("{id}/Calculate")]
        [AutoValidateAntiforgeryToken]
        [HttpGet]
        public IActionResult Calculate(int id, Dictionary<string, string> parameters)
        {
            //var calculator = this.calculatorService.GetById(id);

            //var result = calculator.Module.Function.Calculate(p =>
            //{
            //    for (var i = 0; i <p.Inputs.Count; i++)
            //    {
            //        p.Inputs[i].Value = TypeConverter.ToArray<double[]>(parameters.Select(kv => kv.Value).ToArray());
            //    }
            //});

            //return Json(new { result.Value, result.ValueType });
            return View();
        }
    }
}