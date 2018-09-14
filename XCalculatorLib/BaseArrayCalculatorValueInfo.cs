
namespace XCalculatorLib
{
    public abstract class BaseArrayCalculatorValueInfo<T> : BaseCalculatorValueInfo<T[]>
    {
        protected BaseArrayCalculatorValueInfo(string name = null, string description = null, string unitName = null)
            : base(name, description, unitName)
        {
        }
    }
}
