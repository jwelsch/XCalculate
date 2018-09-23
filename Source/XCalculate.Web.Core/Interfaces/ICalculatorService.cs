using System.Collections.Generic;

namespace XCalculate.Web.Core.Interfaces
{
    public interface ICalculatorService
    {
        IList<ICalculator> GetAll();

        ICalculator GetById(int id);
    }
}
