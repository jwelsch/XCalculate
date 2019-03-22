using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XCalculate.Web.App.Models;
using XCalculate.Web.Core.Interfaces;

namespace XCalculate.Web.App.Controllers
{
    public class SearchController : Controller
    {
        private readonly ICalculatorService calculatorService;

        public SearchController(ICalculatorService calculatorService)
        {
            this.calculatorService = calculatorService;
        }

        [Route("[controller]")]
        [Route("[controller]/[action]")]
        public IActionResult Index([FromQuery] string s)
        {
            var calculators = this.calculatorService.GetAll();
            var search = new FunctionInfoSearch();
            var viewModel = new SearchModel()
            {
                CalculatorIds = calculators
                                    .Where(i => search.IsMatch(i.Module.Function.FunctionInfo, s, FunctionInfoSearch.Target.All))
                                    .OrderBy(i => i.Module.Function.FunctionInfo.Name).Select(i => i.Id)
                                    .ToList()
            };

            return View("Index", viewModel);
        }

        [Route("[controller]/[action]")]
        [HttpPost]
        public IActionResult Search([FromForm] string s)
        {
            var calculators = this.calculatorService.GetAll();
            var search = new FunctionInfoSearch();
            var viewModel = new SearchResultModel()
            {
                CalculatorIds = calculators
                                    .Where(i => search.IsMatch(i.Module.Function.FunctionInfo, s, FunctionInfoSearch.Target.All))
                                    .OrderBy(i => i.Module.Function.FunctionInfo.Name).Select(i => i.Id)
                                    .ToList()
            };

            return View("Result", viewModel);
        }
    }
}