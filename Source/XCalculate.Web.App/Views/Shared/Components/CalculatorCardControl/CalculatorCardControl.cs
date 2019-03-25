using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using XCalculate.Web.Core.Interfaces;

namespace XCalculate.Web.App.Components
{
    public class CalculatorCardControl : ViewComponent
    {
        private readonly ICalculatorRepository repository;

        public CalculatorCardControl(ICalculatorRepository repository)
        {
            this.repository = repository;
        }

#pragma warning disable 1998
        public async Task<IViewComponentResult> InvokeAsync(int calculatorId)
#pragma warning restore 1998
        {
            var calculator = this.repository.GetById(calculatorId);

            var model = new CalculatorCardControlModel()
            {
                Title = calculator.Module.Function.FunctionInfo.Name,
                Description = calculator.Module.Function.FunctionInfo.Description,
                Tags = calculator.Module.Function.FunctionInfo.Tags,
                Uri = new Uri(Url.Action("Index", "Calculator", new { calculatorId }), UriKind.Relative)
            };

            return View("Default", model);
        }
    }
}
