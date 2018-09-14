
namespace XCalculatorLib
{
    public class DoubleCalculatorValue : BaseCalculatorValue<double>
    {
        public DoubleCalculatorValue(double? value = null, DoubleCalculatorValueInfo info = null, ValueValidator<double> validator = null)
            : base(value ?? 0, info, validator)
        {
        }
    }
}
