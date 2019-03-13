using System.Collections;

namespace XCalculateLib
{
    public class ArrayValue<T> : BaseArrayValue<T> where T : IList
    {
        public ArrayValue(T value, IValueInfo info = null, ValueValidator<T> validator = null)
            : base(value, info, validator)
        {
        }
    }
}
