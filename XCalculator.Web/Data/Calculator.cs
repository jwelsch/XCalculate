using XCalculatorLib;

namespace XCalculator.Web.Data
{
    public class Calculator : ICalculator
    {
        public int Id
        {
            get;
            private set;
        }

        public ICalculatorModule Module
        {
            get;
            private set;
        }

        public Calculator(int id, ICalculatorModule module)
        {
            this.Id = id;
            this.Module = module;
        }
    }
}
