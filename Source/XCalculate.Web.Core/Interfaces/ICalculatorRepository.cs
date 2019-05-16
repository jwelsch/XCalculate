using System.Collections.Generic;
using System.ComponentModel;
using XCalculate.Web.Core.Entities;

namespace XCalculate.Web.Core.Interfaces
{
    public interface ICalculatorRepository
    {
        ICalculator[] GetAll();

        ICalculator GetById(int id);

        void UpdateStore(IEnumerable<ICalculator> calculators);

        Tag[] GetAllTags(ListSortDirection sort = ListSortDirection.Ascending);

        int GetCount();
    }
}
