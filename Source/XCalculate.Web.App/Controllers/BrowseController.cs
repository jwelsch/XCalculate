using Microsoft.AspNetCore.Mvc;
using System.Linq;
using XCalculate.Web.App.Models;
using XCalculate.Web.Core;
using XCalculate.Web.Core.Interfaces;

namespace XCalculate.Web.App.Controllers
{
    public class BrowseController : Controller
    {
        private readonly ICalculatorService calculatorService;

        public BrowseController(ICalculatorService calculatorService)
        {
            this.calculatorService = calculatorService;
        }

        [Route("[controller]")]
        [HttpGet]
        public IActionResult Index([FromQuery] string[] s = null)
        {
            var calculators = this.calculatorService.Filter(s, CalculatorFilterTarget.All, false, false, MultipleFilterMatch.And);

            var vm = new BrowseModel
            {
                CalculatorIds = calculators.Select(i => i.Id).ToList(),
                Filters = s
            };

            return View(vm);
        }
    }
}
