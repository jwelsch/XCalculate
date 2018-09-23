using System.Collections.Generic;
using System.Linq;
using XCalculate.Web.Core.Interfaces;

namespace XCalculate.Web.Infrastructure.Data.Repositories
{
    public class CalculatorRepository : ICalculatorRepository
    {
        private readonly List<ICalculator> calculators = new List<ICalculator>();

        public IList<ICalculator> GetAll()
        {
            return this.calculators;
        }

        public ICalculator GetById(int id)
        {
            return this.calculators.FirstOrDefault(i => i.Id == id);
        }

        public void UpdateStore(IEnumerable<ICalculator> calculators)
        {
            this.calculators.Clear();
            this.calculators.AddRange(calculators);
        }
    }
}
