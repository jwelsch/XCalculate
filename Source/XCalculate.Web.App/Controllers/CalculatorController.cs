using Microsoft.AspNetCore.Mvc;
using XCalculate.Web.App.Models;
using XCalculate.Web.Core.Interfaces;

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
        public IActionResult Index(int id)
        {
            var calculator = this.calculatorService.GetById(id);

            var vm = new CalculatorIndexViewModel()
            {
                Id = calculator.Id,
                Name = calculator.Module.Function.FunctionInfo.Name
            };

            return View(vm);
        }
    }
}