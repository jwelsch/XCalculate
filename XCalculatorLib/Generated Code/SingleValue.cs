namespace XCalculatorLib
{
    public class SingleValue : BaseValue<float>
    {
        public SingleValue(float value, SingleValueInfo info = null, ValueValidator<float> validator = null)
            : base(value, info, validator)
        {
        }
    }
}

