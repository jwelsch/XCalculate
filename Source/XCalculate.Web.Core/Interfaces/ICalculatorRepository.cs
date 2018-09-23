using System.Collections.Generic;

namespace XCalculate.Web.Core.Interfaces
{
    public interface ICalculatorRepository
    {
        IList<ICalculator> GetAll();

        ICalculator GetById(int id);

        void UpdateStore(IEnumerable<ICalculator> calculators);
    }
}
