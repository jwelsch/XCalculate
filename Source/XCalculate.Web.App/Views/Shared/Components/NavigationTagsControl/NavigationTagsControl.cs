using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XCalculate.Web.Core.Interfaces;

namespace XCalculate.Web.App.Components
{
    public class NavigationTagsControl : ViewComponent
    {
        private readonly ICalculatorService calculatorService;

        public NavigationTagsControl(ICalculatorService calculatorService)
        {
            this.calculatorService = calculatorService;
        }

#pragma warning disable 1998
        public async Task<IViewComponentResult> InvokeAsync()
#pragma warning restore 1998
        {
            var model = new NavigationTagsControlModel
            {
                Tags = this.calculatorService.GetAllTags()
            };

            return View("Default", model);
        }
    }
}
