using System;
using System.Reflection;
using XCalculatorLib;

namespace TestCalculators
{
    public class CalculatorAssemblyInfo : DefaultCalculatorAssemblyInfo
    {
        public CalculatorAssemblyInfo()
            : base(new Version("1.0.0"), new DefaultAuthorInfo("Justin Welsch", "j.welsch@gmail.com", new Uri("http://www.digimodern.com")))
        {
        }
    }
}
