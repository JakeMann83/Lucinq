using System.Collections.Generic;
using Lucinq.Core.Enums;
using Lucinq.Core.Interfaces;
using Lucinq.Core.QueryTypes;

namespace Lucinq.Core.Querying
{
    public interface ICoreQueryBuilder
    {
        /// <summary>
        /// Gets or sets whether queries are case sensitive by default
        /// </summary>
        bool CaseSensitive { get; set; }

        /// <summary>
        /// Gets or sets the occurance value for the query builder
        /// </summary>
        Matches Occur { get; set; }

        /// <summary>
        /// Gets or sets the default occur value for child queries within the builder
        /// </summary>
        Matches DefaultChildrenOccur { get; set; }

        /// <summary>
        /// Gets the child queries in the builder
        /// </summary>
        Dictionary<string, IQueryReference> Queries { get; }

        /// <summary>
        /// Adds a query to the current group
        /// </summary>
        /// <param name="query">The query to add</param>
        /// <param name="occur">The occur value for the query</param>
        /// <param name="key">A key to allow manipulation from the dictionary later on (a default key will be generated if none is specified</param>
        void Add(IQuery query, Matches occur, string key = null);
    }
}
