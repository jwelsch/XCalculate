namespace XCalculateLib
{
    public interface IValueInfo
    {
        string Name
        {
            get;
        }

        string Description
        {
            get;
        }

        IUnit Unit
        {
            get;
        }
    }
}
