
namespace XCalculatorLib
{
    public class DefaultCalculatorFunctionInfo : ICalculatorFunctionInfo
    {
        public string Name
        {
            get;
            protected set;
        }

        public string Description
        {
            get;
            protected set;
        }

        public string[] Tags
        {
            get;
            protected set;
        }

        public DefaultCalculatorFunctionInfo(string name, string description = null, params string[] tags)
        {
            this.Name = name;
            this.Description = description;
            this.Tags = tags;
        }
    }
}
