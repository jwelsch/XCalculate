using System;
using XCalculateLib;

namespace XCalculate.Web.App
{
    /// <summary>
    /// Searches an IFunctionInfo object for a specifc term.
    /// </summary>
    public class FunctionInfoSearch
    {
        /// <summary>
        /// Describes which part of the IFunctionInfo object to search.
        /// </summary>
        [Flags]
        public enum Target
        {
            /// <summary>
            /// All properties of the object.
            /// </summary>
            All,

            /// <summary>
            /// The name property.
            /// </summary>
            Name,

            /// <summary>
            /// The tags property.
            /// </summary>
            Tags,

            /// <summary>
            /// The description property.
            /// </summary>
            Description
        }

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
        /// Constructor.
        /// </summary>
        /// <param name="matchCase">True to match the case of the property and the search term, false otherwise.</param>
        /// <param name="matchWholeString">True to have the match succeed only if the entire word is matched, false otherwise.</param>
        public FunctionInfoSearch(bool matchCase = false, bool matchWholeString = false)
        {
            this.MatchCase = matchCase;
            this.MatchWholeString = matchWholeString;
        }

        /// <summary>
        /// Performs the search on an IFunctionInfo object.
        /// </summary>
        /// <param name="functionInfo">Object to perform the search on.</param>
        /// <param name="term">Term to search for.</param>
        /// <param name="target">Property of the object to search.</param>
        /// <returns>True if there is a match, false otherwise.</returns>
        public bool IsMatch(IFunctionInfo functionInfo, string term, Target target)
        {
            var isMatch = false;

            if (!isMatch && (target == Target.All || target == Target.Name))
            {
                isMatch = this.Compare(functionInfo.Name, term);
            }

            if (!isMatch && (target == Target.All || target == Target.Tags))
            {
                for (var i = 0; i < functionInfo.Tags.Length && !isMatch; i++)
                {
                    isMatch = this.Compare(functionInfo.Tags[i], term);
                }
            }

            if (!isMatch && (target == Target.All || target == Target.Description))
            {
                isMatch = this.Compare(functionInfo.Description, term);
            }

            return isMatch;
        }

        /// <summary>
        /// Compares two strings together using rules set by the caller.
        /// </summary>
        /// <param name="toSearch">String to search.</param>
        /// <param name="term">String to search for.</param>
        /// <returns>True if there is a match, false otherwise.</returns>
        private bool Compare(string toSearch, string term)
        {
            var result = false;

            if (this.MatchWholeString)
            {
                result = string.Compare(toSearch, term, !this.MatchCase) == 0;
            }
            else
            {
                result = toSearch.IndexOf(term, this.MatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase) != -1;
            }

            return result;
        }
    }
}
