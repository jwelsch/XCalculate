using System;
using System.Linq;
using XCalculateLib;

namespace XCalculate.Web.Core
{
    /// <summary>
    /// Searches an IFunctionInfo object for a specifc term.
    /// </summary>
    public class FunctionInfoSearch
    {
        /// <summary>
        /// Gets or sets whether to match the case of the property and the search term, false otherwise.
        /// </summary>
        public bool MatchCase
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether to have the match succeed only if the entire word is matched, false otherwise.
        /// </summary>
        public bool MatchWholeString
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets how to combine the filter results.
        /// </summary>
        public MultipleFilterMatch MultipleFilterMatch
        {
            get;
            set;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="matchCase">True to match the case of the property and the search term, false otherwise.</param>
        /// <param name="matchWholeString">True to have the match succeed only if the entire word is matched, false otherwise.</param>
        /// <param name="multipleFilterMatch">How to combine the filter results.</param>
        public FunctionInfoSearch(bool matchCase = false, bool matchWholeString = false, MultipleFilterMatch multipleFilterMatch = MultipleFilterMatch.And)
        {
            this.MatchCase = matchCase;
            this.MatchWholeString = matchWholeString;
            this.MultipleFilterMatch = multipleFilterMatch;
        }

        /// <summary>
        /// Performs the search on an IFunctionInfo object.
        /// </summary>
        /// <param name="functionInfo">Object to perform the search on.</param>
        /// <param name="terms">Array of terms to search for.</param>
        /// <param name="target">Property of the object to search.</param>
        /// <returns>True if there is a match, false otherwise.</returns>
        public bool IsMatch(IFunctionInfo functionInfo, string[] terms, CalculatorFilterTarget target)
        {
            return this.MultipleFilterMatch == MultipleFilterMatch.And
                ? this.IsAndMatch(functionInfo, terms, target)
                : this.IsOrMatch(functionInfo, terms, target);
        }

        /// <summary>
        /// Performs the search on an IFunctionInfo object and combines the results using logical OR.
        /// </summary>
        /// <param name="functionInfo">Object to perform the search on.</param>
        /// <param name="terms">Array of terms to search for.</param>
        /// <param name="target">Property of the object to search.</param>
        /// <returns>True if there is a match, false otherwise.</returns>
        public bool IsOrMatch(IFunctionInfo functionInfo, string[] terms, CalculatorFilterTarget target)
        {
            var isMatch = false;

            if (!isMatch && (target == CalculatorFilterTarget.All || target == CalculatorFilterTarget.Name))
            {
                isMatch = terms.Any(i => this.Compare(functionInfo.Name, i));
            }

            if (!isMatch && (target == CalculatorFilterTarget.All || target == CalculatorFilterTarget.Tags))
            {
                for (var i = 0; i < functionInfo.Tags.Length && !isMatch; i++)
                {
                    isMatch = terms.Any(j => this.Compare(functionInfo.Tags[i], j));
                }
            }

            if (!isMatch && (target == CalculatorFilterTarget.All || target == CalculatorFilterTarget.Description))
            {
                isMatch = terms.Any(i => this.Compare(functionInfo.Description, i));
            }

            return isMatch;
        }

        /// <summary>
        /// Performs the search on an IFunctionInfo object and combines the results using logical AND.
        /// </summary>
        /// <param name="functionInfo">Object to perform the search on.</param>
        /// <param name="terms">Array of terms to search for.</param>
        /// <param name="target">Property of the object to search.</param>
        /// <returns>True if there is a match, false otherwise.</returns>
        public bool IsAndMatch(IFunctionInfo functionInfo, string[] terms, CalculatorFilterTarget target)
        {
            var overallMatch = true;
            var isMatch = false;

            for (var i = 0; i < terms.Length && overallMatch; i++)
            {
                if (!isMatch && (target == CalculatorFilterTarget.All || target == CalculatorFilterTarget.Name))
                {
                    isMatch = this.Compare(functionInfo.Name, terms[i]);
                }

                if (!isMatch && (target == CalculatorFilterTarget.All || target == CalculatorFilterTarget.Tags))
                {
                    for (var j = 0; j < functionInfo.Tags.Length && !isMatch; j++)
                    {
                        isMatch = this.Compare(functionInfo.Tags[j], terms[i]);
                    }
                }

                if (!isMatch && (target == CalculatorFilterTarget.All || target == CalculatorFilterTarget.Description))
                {
                    isMatch = this.Compare(functionInfo.Description, terms[i]);
                }

                overallMatch = isMatch;
                isMatch = false;
            }

            return overallMatch;
        }

        /// <summary>
        /// Compares two strings together using rules set by the caller.
        /// </summary>
        /// <param name="toSearch">String to search.</param>
        /// <param name="term">String to search for.</param>
        /// <returns>True if there is a match, false otherwise.</returns>
        private bool Compare(string toSearch, string term)
        {
            return this.MatchWholeString
                ? string.Compare(toSearch, term, !this.MatchCase) == 0
                : toSearch.IndexOf(term, this.MatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase) != -1;
        }
    }
}
