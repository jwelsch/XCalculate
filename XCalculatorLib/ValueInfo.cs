namespace XCalculatorLib
{
    public class ValueInfo<T> : BaseValueInfo<T>
    {
        public ValueInfo(string name = null, string description = null, string unitName = null)
            : base(name, description, unitName)
        {
        }
    }
}
