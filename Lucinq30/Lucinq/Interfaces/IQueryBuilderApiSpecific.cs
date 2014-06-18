using System.Collections.Generic;
using Lucene.Net.Search;
using Lucinq.Core.Enums;

namespace Lucinq.Interfaces
{
    public partial interface IQueryBuilderApiSpecific
    {
        /// <summary>
        /// Gets the sort fields
        /// </summary>
        List<SortField> SortFields { get; }

        /// <summary>
        /// Gets the current sort 
        /// </summary>
        Sort CurrentSort { get; set; }

        /// <summary>
        /// Builds the query
        /// </summary>
        /// <returns>The query built from the queries and groups that have been added</returns>
        Query Build();

        /// <summary>
        /// Adds a query to the current group
        /// </summary>
        /// <param name="query">The query to add</param>
        /// <param name="occur">The occur value for the query</param>
        /// <param name="key">A key to allow manipulation from the dictionary later on (a default key will be generated if none is specified</param>
        void Add(Query query, Matches occur, string key = null);
    }
}
