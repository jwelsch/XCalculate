using XCalculatorLib;

namespace XCalculator.Web.Data
{
    public interface ICalculator
    {
        int Id
        {
            get;
        }

        IModule Module
        {
            get;
        }
    }
}
