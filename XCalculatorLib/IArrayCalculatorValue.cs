
namespace XCalculatorLib
{
    public interface IArrayCalculatorValue<T> : ICalculatorValue
    {
        new ICalculatorValueInfo Info
        {
            get;
        }

        new T[] Value
        {
            get;
            set;
        }
    }
}
