namespace XCalculateLib
{
    public abstract class BaseValueInfo : IValueInfo
    {
        public string Name
        {
            get;
        }

        public string Description
        {
            get;
        }

        public IUnit Unit
        {
            get;
        }

        protected BaseValueInfo(string name = null, string description = null, IUnit unit = null)
        {
            this.Name = name ?? string.Empty;
            this.Description = description ?? string.Empty;
            this.Unit = unit;
        }
    }
}
