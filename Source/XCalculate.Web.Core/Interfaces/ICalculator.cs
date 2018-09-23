using XCalculateLib;

namespace XCalculate.Web.Core.Interfaces
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
