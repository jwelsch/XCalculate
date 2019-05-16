using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public Tag[] GetAllTags(ListSortDirection sort = ListSortDirection.Ascending)
        {
            var tags = this.GetAllTags();

            if (sort == ListSortDirection.Ascending)
            {
                Array.Sort(tags, (a, b) =>
                {
                    return string.Compare(a.Text, b.Text, true);
                });
            }
            else
            {
                Array.Sort(tags, (a, b) =>
                {
                    return -string.Compare(a.Text, b.Text, true);
                });
            }

            return tags;
        }

        public int GetCount()
        {
            return this.calculators.Count;
        }
    }
}
