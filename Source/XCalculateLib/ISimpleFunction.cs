namespace XCalculateLib
{
    public interface ISimpleFunction<T> : IFunction
    {
        T Calculate(params T[] values);
    }
}
