using System.Collections.Generic;
using Lucene.Net.Search;

namespace Lucinq.Interfaces
{
	public interface IHierarchicalQueryGroup
	{
		#region [ Properties ]

		/// <summary>
		/// Gets the parent query builder
		/// </summary>
		IQueryBuilder Parent { get; }

		/// <summary>
		/// Gets the child groups in the builder
		/// </summary>
		List<IQueryBuilder> Groups { get; }

        /// <summary>
        /// Gets the sort fields
        /// </summary>
        List<SortField> SortFields { get; }

        /// <summary>
        /// Gets the current sort 
        /// </summary>
		Sort CurrentSort { get; set; }

		#endregion
	}
}
