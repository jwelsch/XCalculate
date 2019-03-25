using System.Collections.Generic;
using System.Linq;
using XCalculate.Web.Core.Interfaces;

namespace XCalculate.Web.Core.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ICalculatorRepository repository;

        public CalculatorService(ICalculatorRepository repository)
        {
            this.repository = repository;
        }

        public ICalculator[] GetAll()
        {
            return this.repository.GetAll();
        }

        public ICalculator GetById(int id)
        {
            return this.repository.GetById(id);
        }

        public ICalculator[] Filter(string term, CalculatorFilterTarget target, bool matchCase, bool matchWholeString)
        {
            var search = new FunctionInfoSearch(matchCase, matchWholeString);
            var allCalculators = repository.GetAll();

            var selectedCalculators = string.IsNullOrEmpty(term) ? allCalculators : allCalculators.Where(i => search.IsMatch(i.Module.Function.FunctionInfo, term, CalculatorFilterTarget.All));

            return selectedCalculators
                    .OrderBy(i => i.Module.Function.FunctionInfo.Name)
                    .ToArray();
        }
    }
}