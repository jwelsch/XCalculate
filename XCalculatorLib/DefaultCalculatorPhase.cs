using System;
using System.Collections.Generic;
using System.Text;
using XCalculatorLib.Interfaces;

namespace XCalculatorLib
{
    public class DefaultCalculatorPhase : ICalculatorPhase
    {
        private readonly List<ICalculatorValueInfo> inputInfos;

        public string Name
        {
            get;
            private set;
        }

        public string Description
        {
            get;
            private set;
        }

        public IReadOnlyList<ICalculatorValueInfo> InputInfos
        {
            get
            {
                return this.inputInfos;
            }
        }

        public DefaultCalculatorPhase(IEnumerable<ICalculatorValueInfo> inputInfos)
        {
            this.inputInfos = new List<ICalculatorValueInfo>(inputInfos);
        }

        public DefaultCalculatorPhase(string name, string description, IEnumerable<ICalculatorValueInfo> inputInfos)
            : this(inputInfos)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
