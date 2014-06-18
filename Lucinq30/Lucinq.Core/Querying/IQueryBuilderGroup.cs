using System;
using Lucinq.Core.Enums;

namespace Lucinq.Core.Querying
{
    public interface IQueryBuilderGroup<out TGroup> where TGroup : IQueryBuilderGroup<TGroup>
    {
		#region [ Methods ]

		/// <summary>
		/// A setup method to aid multiple query setup
		/// </summary>
		/// <param name="queries">Comma seperated lambda actions</param>
		/// <returns>The input querybuilder</returns>
        TGroup Setup(params Action<TGroup>[] queries);
        
        /// <summary>
        /// Sets up term queries for each of the values specified
        /// (usually or / and / not in depending on the occur specified)
        /// </summary>
        /// <param name="fieldName">The field name to search within</param>
        /// <param name="fieldValues">The values to match</param>
        /// <param name="occur">Whether it must, must not or should occur in the field</param>
        /// <param name="boost">A boost multiplier (1 is default / normal).</param>
        /// <param name="caseSensitive">Whether the value is explicitly case sensitive (else use the query builders value)</param>
        /// <returns>The input query builder</returns>
        TGroup Terms(string fieldName, string[] fieldValues, Matches occur = Matches.NotSet, float? boost = null, bool? caseSensitive = null);

        /// <summary>
        /// Creates a set of keywords
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="fieldValues"></param>
        /// <param name="occur"></param>
        /// <param name="boost"></param>
        /// <param name="key"></param>s
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        TGroup Keywords(string fieldName, string[] fieldValues, Matches occur = Matches.NotSet, float? boost = null, string key = null, bool? caseSensitive = null);

        TGroup WildCards(string fieldName, string[] fieldValues, Matches occur = Matches.NotSet,
		                                        float? boost = null, bool? caseSensitive = null);

		/// <summary>
		/// Creates a simple group that MUST occur, each item of which MUST occur by default
		/// </summary>
		/// <param name="queries">The lamdba expressions showing queries</param>
		/// <returns></returns>
        TGroup And(params Action<TGroup>[] queries);

		/// <summary>
		/// Creates a simple group allowing the specification of whether it should occur, each item of which MUST occur by default
		/// </summary>
		/// <param name="occur">Whether the group must / should occur</param>
		/// <param name="queries">The lamdba expressions showing queries</param>
        TGroup And(Matches occur = Matches.NotSet, params Action<TGroup>[] queries);

		/// <summary>
		/// Creates a simple group that MUST occur, each item of which SHOULD occur by default
		/// </summary>
		/// <param name="queries">The lamdba expressions showing queries</param>
        TGroup Or(params Action<TGroup>[] queries);

		/// <summary>
		/// Creates a simple group allowing the specification of whether it should occur, each item of which SHOULD occur by default
		/// </summary>
		/// <param name="occur">Whether the group must / should occur</param>
		/// <param name="queries">The lamdba expressions showing queries</param>
        TGroup Or(Matches occur = Matches.NotSet, params Action<TGroup>[] queries);

		/// <summary>
		/// Creates a simple group allowing the specification of whether it should occur, and specification of each items occurance.
		/// </summary>
		/// <param name="occur">Whether the group must / should occur</param>
		/// <param name="childrenOccur">Whether the child query should occur by default</param>
		/// <param name="queries">The lamdba expressions showing queries</param>
        TGroup Group(Matches occur = Matches.NotSet, Matches childrenOccur = Matches.NotSet, params Action<TGroup>[] queries);

        TGroup Sort(string fieldName, bool sortDescending = false, SortType sortType = SortType.String);

        TGroup Phrase(string fieldName, string[] fieldValues, int slop, Matches occur = Matches.NotSet, float? boost = null, bool? caseSensitive = null);

		#endregion

        #region [ Creation ]

        TGroup CreateAndGroup(params Action<TGroup>[] queries);

        TGroup CreateAndGroup(Matches occur, params Action<TGroup>[] queries);

        TGroup CreateOrGroup(params Action<TGroup>[] queries);

        TGroup CreateOrGroup(Matches occur, params Action<TGroup>[] queries);

        #endregion
	}
}