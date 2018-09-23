using System.Collections.Generic;
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

        public IList<ICalculator> GetAll()
        {
            return this.repository.GetAll();
        }

        public ICalculator GetById(int id)
        {
            return this.repository.GetById(id);
        }
    }
}