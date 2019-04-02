using System.Collections.Generic;

namespace XCalculate.Web.Core.Interfaces
{
    public interface ICalculatorRepository
    {
        ICalculator[] GetAll();

        ICalculator GetById(int id);

        void UpdateStore(IEnumerable<ICalculator> calculators);

        string[] GetAllTags();
    }
}
