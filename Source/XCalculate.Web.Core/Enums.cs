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
}
