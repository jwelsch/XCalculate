using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using XCalculate.Web.App.Components;
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
            var viewModel = new HomeIndexModel();

            return View(viewModel);
        }

        [Route("[controller]/[action]")]
        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("[controller]/[action]")]
        [HttpGet]
        //[ChildActionOnly]
        public IActionResult NavigationTags()
        {
            var vm = new NavigationTagsControlModel
            {
                Tags = this.calculatorService.GetAllTags()
            };

            return PartialView(vm);
        }
    }
}
