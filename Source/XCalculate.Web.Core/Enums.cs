namespace XCalculate.Web.Core
{
    /// <summary>
    /// Describes which part of the IFunctionInfo object to search.
    /// </summary>
    public enum CalculatorFilterTarget
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
    /// When multiple filters are being matched, determines how the filters are combined.
    /// </summary>
    public enum MultipleFilterMatch
    {
        /// <summary>
        /// The filter results are combined using logical AND.
        /// </summary>
        And,

        /// <summary>
        /// The filter results are combined using logical OR.
        /// </summary>
        Or
    }
}
