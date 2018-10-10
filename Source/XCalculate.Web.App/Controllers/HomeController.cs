using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using XCalculate.Web.App.Models;
using XCalculate.Web.Core.Interfaces;

namespace XCalculate.Web.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculatorService calculatorService;

        public HomeController(ICalculatorService calculatorService)
        {
            this.calculatorService = calculatorService;
        }

        [Route("")]
        [Route("[controller]/[action]")]
        [HttpGet]
        public IActionResult Index()
        {
            var url = Url.Action("Index", "Calculator", new { id = 1 });

            var calculators = this.calculatorService.GetAll();
            var viewModel = new HomeIndexModel()
            {
                CalculatorLinks = calculators.Select(i =>
                    new CalculatorLink(
                        i.Module.Function.FunctionInfo.Name,
                        i.Module.Function.FunctionInfo.Description,
                        i.Module.Function.FunctionInfo.Tags,
                        new Uri(Url.Action("Index", "Calculator", new { id = i.Id }), UriKind.Relative)
                )).ToList()
            };

            return View(viewModel);
        }

        [Route("[controller]/[action]")]
        [HttpGet]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Route("[controller]/[action]")]
        [HttpGet]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Route("[controller]/[action]")]
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("[controller]/[action]")]
        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
