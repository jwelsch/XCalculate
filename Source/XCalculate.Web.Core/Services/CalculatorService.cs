using System.ComponentModel;
using System.Linq;
using XCalculate.Web.Core.Entities;
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

        public ICalculator[] Filter(string[] terms, CalculatorFilterTarget target, bool matchCase, bool matchWholeString, MultipleFilterMatch multipleFilterMatch)
        {
            var search = new FunctionInfoSearch(matchCase, matchWholeString, multipleFilterMatch);
            var allCalculators = this.repository.GetAll();

            var nonEmptyTerms = terms == null ? new string[0] : terms.Where(i => !string.IsNullOrWhiteSpace(i)).ToArray();

            var selectedCalculators = nonEmptyTerms.Length == 0 ? allCalculators : allCalculators.Where(i => search.IsMatch(i.Module.Function.FunctionInfo, nonEmptyTerms, CalculatorFilterTarget.All));

            return selectedCalculators
                    .OrderBy(i => i.Module.Function.FunctionInfo.Name)
                    .ToArray();
        }

        public Tag[] GetAllTags()
        {
            return this.repository.GetAllTags(ListSortDirection.Ascending);
        }

        public int GetCount()
        {
            return this.repository.GetCount();
        }
    }
}