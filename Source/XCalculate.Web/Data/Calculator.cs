using XCalculateLib;

namespace XCalculate.Web.Data
{
    public class Calculator : ICalculator
    {
        public int Id
        {
            get;
            private set;
        }

        public IModule Module
        {
            get;
            private set;
        }

        public Calculator(int id, IModule module)
        {
            this.Id = id;
            this.Module = module;
        }
    }
}
