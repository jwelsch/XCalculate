
namespace XCalculateLib
{
    public abstract class BaseArrayValueInfo<T> : BaseValueInfo<T[]>
    {
        protected BaseArrayValueInfo(string name = null, string description = null, string unitName = null)
            : base(name, description, unitName)
        {
        }
    }
}
