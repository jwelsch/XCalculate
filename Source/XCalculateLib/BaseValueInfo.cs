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

        public string UnitName
        {
            get;
        }

        protected BaseValueInfo(string name = null, string description = null, string unitName = null)
        {
            this.Name = name ?? string.Empty;
            this.Description = description ?? string.Empty;
            this.UnitName = unitName ?? string.Empty;
        }
    }
}
