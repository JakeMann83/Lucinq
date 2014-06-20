using Lucinq.Core.Enums;

namespace Lucinq.Core.Interfaces
{
    /// <summary>
    /// The query reference interface
    /// </summary>
    public interface IQueryReference<TQuery> : IQueryReference
    {
        /// <summary>
        /// Gets or sets the query
        /// </summary>
        TQuery Query { get; set; }
    }

    public interface IQueryReference
    {
        /// <summary>
        /// Gets or sets the matches value for the reference
        /// </summary>
        Matches Occur { get; set; }
    }
}
