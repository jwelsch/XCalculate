
namespace XCalculatorLib
{
    public interface IArrayValue<T> : IValue
    {
        new IValueInfo Info
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
