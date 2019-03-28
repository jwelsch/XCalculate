namespace XCalculate.Web.Core.Interfaces
{
    public interface ICalculatorService
    {
        ICalculator[] GetAll();

        ICalculator GetById(int id);

        ICalculator[] Filter(string[] terms, CalculatorFilterTarget target, bool matchCase, bool matchWholeString, MultipleFilterMatch multipleFilterMatch);
    }
}
