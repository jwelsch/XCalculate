using XCalculateLib;

namespace XCalculate.Web.Data
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
