using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCalculateLib;

namespace XCalculate.Web.Data
{
    public interface ICalculatorRepository
    {
        IEnumerable<string> GetNames();

        ICalculator GetById(int id);

        void UpdateStore(IEnumerable<ICalculator> calculators);
    }
}
