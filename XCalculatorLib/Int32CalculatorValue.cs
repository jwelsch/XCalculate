
namespace XCalculatorLib
{
    public class Int32CalculatorValue : BaseCalculatorValue<int>
    {
        public Int32CalculatorValue(object value = null, string name = null, string description = null, string unitName = null)
            : base(new Int32CalculatorValueInfo(name, description, unitName), value)
        {
        }

        public new int Value
        {
            get
            {
                return (int)base.Value;
            }

            set
            {
                base.Value = value;
            }
        }
    }
}
