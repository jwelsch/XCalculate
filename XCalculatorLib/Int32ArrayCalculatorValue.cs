
namespace XCalculatorLib
{
    public class Int32ArrayCalculatorValue : BaseArrayCalculatorValue<int>
    {
        public Int32ArrayCalculatorValue(int[] value = null, Int32ArrayCalculatorValueInfo info = null, Range lengthRange = null)
            : base(value, info, lengthRange)
        {
        }
    }
}
