using Lucinq.Core.Enums;
using Lucinq.Core.Querying;
using Lucinq.Core.QueryTypes;

namespace Lucinq.Core.Interfaces
{
    public interface IAdaptableQueryReference<TQuery, TNative> : IQueryReference<TQuery> where TQuery : IQuery
    {
        IQueryAdapter<TQuery, TNative> Adapter { get; set; } 
    }


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
