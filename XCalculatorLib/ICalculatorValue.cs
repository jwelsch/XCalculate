
namespace XCalculatorLib
{
    public interface ICalculatorValue
    {
        ICalculatorValueInfo Info
        {
            get;
        }

        object Value
        {
            get;
            set;
        }
    }
}
