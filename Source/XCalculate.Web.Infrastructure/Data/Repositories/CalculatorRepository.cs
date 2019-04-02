using System.Collections.Generic;
using System.Linq;
using XCalculate.Web.Core.Entities;
using XCalculate.Web.Core.Interfaces;

namespace XCalculate.Web.Infrastructure.Data.Repositories
{
    public class CalculatorRepository : ICalculatorRepository
    {
        private readonly List<ICalculator> calculators = new List<ICalculator>();

        public ICalculator[] GetAll()
        {
            return this.calculators.ToArray();
        }

        public ICalculator GetById(int id)
        {
            return this.calculators.FirstOrDefault(i => i.Id == id);
        }

        public void UpdateStore(IEnumerable<ICalculator> calculators)
        {
            this.calculators.Clear();
            this.calculators.AddRange(calculators);
        }

        public Tag[] GetAllTags()
        {
            var tags = new List<Tag>();

            foreach (var calculator in this.calculators)
            {
                foreach (var tagText in calculator.Module.Function.FunctionInfo.Tags)
                {
                    var tag = tags.FirstOrDefault(i => i.Text == tagText);

                    if (tag == null)
                    {
                        tags.Add(new Tag(tagText));
                    }
                    else
                    {
                        tag.IncrementCount();
                    }
                }
            }

            return tags.ToArray();
        }
    }
}
